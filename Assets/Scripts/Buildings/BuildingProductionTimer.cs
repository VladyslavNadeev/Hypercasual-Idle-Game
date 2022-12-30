using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Buildings
{
    public class BuildingProductionTimer
    {
        public delegate void BuildingProductionTimerHandler();
        public event BuildingProductionTimerHandler Ticked;
        public float TickTime;

        private CancellationTokenSource tickingTaskTokenSource;
        private Task _tickingTask;

        public void Start()
        {
            if (TickTime <= 0)
                throw new ArgumentException($"Tick time cant be less or equal zero");

            tickingTaskTokenSource = new CancellationTokenSource();
            CancellationToken ct = tickingTaskTokenSource.Token;

            _tickingTask = tickingTask(ct);
        }
        public void Stop()
        {
            if (_tickingTask == null)
                return;

            tickingTaskTokenSource.Cancel();
            _tickingTask = null;
        }

        private async Task tickingTask(CancellationToken ct)
        {
            ct.ThrowIfCancellationRequested();

            while (true)
            {
                if (ct.IsCancellationRequested)
                    ct.ThrowIfCancellationRequested();

                try
                {
                    Ticked?.Invoke();
                }
                catch (Exception ex)
                {
                    Debug.LogError($"{ex.Message} \n {ex.StackTrace}");
                }
                await Task.Delay((int)(TickTime * 1000));
            }
        }
    }
}
