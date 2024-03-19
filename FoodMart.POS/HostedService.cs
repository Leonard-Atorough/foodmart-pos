using FoodMart.POS.Extensions;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodMart.POS
{
    public class HostedService : IHostedService
    {
        private readonly ILogger<HostedService> _logger;
        private readonly IHostApplicationLifetime _hostApplicationLifetime;
        private readonly IMainService _mainService;
        private Task<ResultCode>? _mainTask;

        private CancellationTokenSource? _cancellationTokenSource;

        public HostedService(ILogger<HostedService> logger, IHostApplicationLifetime hostApplicationLifetime, IMainService service)
        {
            _logger = logger;
            _hostApplicationLifetime = hostApplicationLifetime;
            _mainService = service;
            _hostApplicationLifetime.ApplicationStarted.Register(OnStarted);
            _hostApplicationLifetime.ApplicationStopped.Register(OnStopped);
            _hostApplicationLifetime.ApplicationStopping.Register(OnStopping);
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _logger.LogApplicationStarting();

            _cancellationTokenSource = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);

            if (_cancellationTokenSource.IsCancellationRequested) return Task.CompletedTask;

            _hostApplicationLifetime.ApplicationStarted.Register(() =>
            {
                var args = Environment.GetCommandLineArgs();

                _logger.LogApplicationStarted();

                _mainTask = ExecuteAsync(args, cancellationToken);
            });
            return Task.CompletedTask;
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _logger.LogApplicationStopped();

            ResultCode resultCode;
            if (_mainTask != null)
            {
                if (!_mainTask.IsCompleted || cancellationToken.IsCancellationRequested)
                {
                    _cancellationTokenSource?.Cancel();
                }
                resultCode = await _mainTask.ConfigureAwait(false);
            }
            else
            {
                resultCode = ResultCode.Aborted;
            }

            Environment.ExitCode = (int) resultCode;

            _logger.LogApplicationExiting(resultCode, (int)resultCode);
        }

        protected async Task<ResultCode> ExecuteAsync(string[] args, CancellationToken cancellationToken)
        {
            try
            {
                return await _mainService.ExecuteAsync(args, cancellationToken);
            }
            catch (TaskCanceledException)
            {
                _logger.LogApplicationCancelled();
                return ResultCode.Cancelled;
            }
            catch (Exception ex) 
            {
                _logger.LogUnhandledException(ex);
                return ResultCode.UnhandledException;
            }
            finally
            {
                _hostApplicationLifetime.StopApplication();
            }
        }

        public void OnStarted() => _logger.LogApplicationStarted();
        public void OnStopping() => _logger.LogApplicationStopping();
        public void OnStopped() => _logger.LogApplicationStopped();

    }
}
