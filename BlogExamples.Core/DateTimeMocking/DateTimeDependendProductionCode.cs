using System;
using System.Collections.Generic;

namespace BlogExamples.Core.DateTimeMocking
{
    public class DateTimeDependendProductionCode
    {
        private IAmActiveMetersLoader _meterLoader;
        private List<long> _activeMeters;

        public DateTimeDependendProductionCode(IAmActiveMetersLoader meterLoader)
        {
            _meterLoader = meterLoader;
            TimeForNextPeriodicCheck = DateTime.Now.Date.AddHours(22); //Check should be conducted always at 22:00
        }

        public void DoPeriodicCheckIfNeeded()
        {
            var isItTimeForPeriodicCheck = TimeForNextPeriodicCheck < DateTime.Now;
            if (!isItTimeForPeriodicCheck)
                return;

            _activeMeters = _meterLoader.ReloadAllActiveMeters();

            TimeForNextPeriodicCheck = ComputeTimeForNextCheck();
        }

        #region Irrelevant
        private DateTime TimeForNextPeriodicCheck { get; set; }        
        private DateTime ComputeTimeForNextCheck()
        {
            return DateTime.Now.AddMinutes(1);
        }
        #endregion Irrelevant
    }
}
