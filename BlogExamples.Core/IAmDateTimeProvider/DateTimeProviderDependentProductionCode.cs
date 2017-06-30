using System;

namespace BlogExamples.Core
{
    public class DateTimeProviderDependentProductionCode
    {
        private readonly IAmActiveMetersLoader _meterLoader;
        private readonly IAmDateTimeProvider _dateTimeProvider;

        public DateTimeProviderDependentProductionCode(IAmActiveMetersLoader meterLoader, IAmDateTimeProvider dateTimeProvider)
        {
            _meterLoader = meterLoader;
            _dateTimeProvider = dateTimeProvider;
            TimeForNextPeriodicCheck = _dateTimeProvider.Now.Date.AddHours(22);
        }

        public void DoPeriodicCheckIfNeeded()
        {
            var isItTimeForPeriodicCheck = TimeForNextPeriodicCheck < _dateTimeProvider.Now;
            if (!isItTimeForPeriodicCheck)
                return;

            _meterLoader.ReloadAllActiveMeters();

            TimeForNextPeriodicCheck = ComputeTimeForNextCheck();
        }

        #region Irrelevant
        private DateTime TimeForNextPeriodicCheck { get; set; }
        private static DateTime ComputeTimeForNextCheck()
        {
            return DateTime.Now.AddMinutes(1);
        }
        #endregion Irrelevant
    }
}
