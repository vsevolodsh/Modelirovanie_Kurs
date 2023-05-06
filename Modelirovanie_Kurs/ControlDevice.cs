namespace Modelirovanie_Kurs
{
    internal class ControlDevice
    {
        StateAndConditionsMemory _stAndCndMemory;
        CombinationScheme_D _cmbScheme_D;
        CombinationScheme_Y _cmbScheme_Y;
        OperatingDevice _operatingDevice;

        public ControlDevice(StateAndConditionsMemory stAndCndMemory, CombinationScheme_D cmbScheme_D, CombinationScheme_Y cmbScheme_Y, OperatingDevice operatingDevice)
        {
            _stAndCndMemory = stAndCndMemory;
            _cmbScheme_D = cmbScheme_D;
            _cmbScheme_Y = cmbScheme_Y;
            _operatingDevice = operatingDevice;
        }
        public void ExecuteTact()
        {
            _stAndCndMemory.CurrentStateCode = _cmbScheme_D.NextStateCode;
            _operatingDevice.ConditionsX.CopyTo(_stAndCndMemory.ConditionsX, 0);
            _cmbScheme_Y.SetCurrentOperationsY(_stAndCndMemory.ArrStateA, _stAndCndMemory.ConditionsX);
            _operatingDevice.ExecuteTact(_cmbScheme_Y.OperationsY);
            _cmbScheme_D.setNextStateCode(_stAndCndMemory.ArrStateA, _stAndCndMemory.ConditionsX);
        }
    }
}
