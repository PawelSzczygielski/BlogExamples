using System;

namespace BlogExamples.Core.DateTimeMocking
{
    public class SystemTimeDependendProductionCode
    {
        private readonly IAmActiveMetersLoader _meterLoader;

        public SystemTimeDependendProductionCode(IAmActiveMetersLoader meterLoader)
        {
            _meterLoader = meterLoader;
            TimeForNextPeriodicCheck = SystemTime.Now.Date.AddHours(22); //Check should be conducted always at 22:00
        }

        public void DoPeriodicCheckIfNeeded()
        {
            var isItTimeForPeriodicCheck = TimeForNextPeriodicCheck < SystemTime.Now;
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
