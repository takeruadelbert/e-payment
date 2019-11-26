using BNITapCash.Helper;
using BNITapCash.ConstantVariable;

namespace BNITapCash.Bank.DataModel
{
    public class DataDeduct
    {
        private string _deductResult;
        private int _amount;
        private string _transactionDatetime;
        private string _bank;
        private string _ipAddress;
        private string _operatorName;
        private string _idReader;
        private string _createdDatetime;
        private bool _isError;
        private string _message;

        public DataDeduct(bool isError, string message)
        {
            _isError = isError;
            _message = message;
        }

        public DataDeduct(string deductResult, int amount, string bank, string operatorName, string idReader)
        {
            this._deductResult = deductResult;
            this._amount = amount;
            this._bank = bank;
            this._operatorName = operatorName;
            this._idReader = idReader;
            this._isError = false;
            this._message = Constant.MESSAGE_OK;
        }

        public string DeductResult
        {
            get { return _deductResult; }
            set { _deductResult = value; }
        }

        public int Amount
        {
            get { return _amount; }
            set { _amount = value; }
        }

        public string Bank
        {
            get { return _bank; }
            set { _bank = value; }
        }

        public string OperatorName
        {
            get { return _operatorName; }
            set { _operatorName = value; }
        }

        public string IdReader
        {
            get { return _idReader; }
            set { _idReader = value; }
        }

        public string TransactionDatetime
        {
            get { return TKHelper.GetCurrentDatetimeInDefaultFormat(); }
        }

        public string CreatedDatetime
        {
            get { return TKHelper.GetCurrentDatetimeInDefaultFormat(); }
        }

        public string IpAddress
        {
            get { return TKHelper.GetLocalIPAddress(); }
        }

        public bool IsError
        {
            get { return _isError; }
            set { _isError = value; }
        }

        public string Message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}
