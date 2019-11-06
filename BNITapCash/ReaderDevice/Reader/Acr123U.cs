/*===========================================================================================
 * 
 *  Copyright (C)   : Advanced Card System Ltd
 * 
 *  File            : Acr123.cs
 * 
 *  Description     : Contains Methods and Properties related to ACR123 device's functionality
 * 
 *  Author          : Lyle Macedonio
 *  
 *  Date            : May 14, 2013
 * 
 *  Revision Traile : [Author] / [Date if modification] / [Details of Modifications done] 
 * 
 * =========================================================================================*/

using BNITapCash.Exceptions;
using BNITapCash.Pcsc;
using BNITapCash.Readers.Pcsc;
using System;
using System.Linq;

namespace BNITapCash.Readers.Contactless.Acr123U
{
    public class Acr123U : PcscReader
    {
        //Note: When using 3500 you must use the full command format (E0 00 00 xx xx)
        const uint IOCTL_SMARTCARD_ACR123_ESCAPE_COMMAND = (uint)PcscProvider.FILE_DEVICE_SMARTCARD + 3500 * 4;

        public Acr123U()
            : base()
        {
            base.establishContext();
            operationControlCode = IOCTL_SMARTCARD_ACR123_ESCAPE_COMMAND;
        }

        public Acr123U(string readerName)
            : base(readerName)
        {
            base.establishContext();
            operationControlCode = IOCTL_SMARTCARD_ACR123_ESCAPE_COMMAND;
        }

        #region Helper

        public static byte[] intToByte(int number)
        {
            byte[] tmpByte = new byte[4];

            tmpByte[0] = (byte)((number >> 24) & 0xFF);
            tmpByte[1] = (byte)((number >> 16) & 0xFF);
            tmpByte[2] = (byte)((number >> 8) & 0xFF);
            tmpByte[3] = (byte)(number & 0xFF);

            return tmpByte;
        }

        public static Int32 byteToInt(byte[] data, bool isLittleEndian)
        {
            byte[] tmpArry = new byte[data.Length];
            Array.Copy(data, tmpArry, tmpArry.Length);

            if (tmpArry.Length != 4)
            {
                if (isLittleEndian)
                    Array.Resize(ref tmpArry, 4);
                else
                {
                    Array.Reverse(tmpArry);
                    Array.Resize(ref tmpArry, 4);
                    Array.Reverse(tmpArry);
                }
            }

            if (isLittleEndian)
                return (tmpArry[3] << 24) + (tmpArry[2] << 16) + (tmpArry[1] << 8) + tmpArry[0];
            else
                return (tmpArry[0] << 24) + (tmpArry[1] << 16) + (tmpArry[2] << 8) + tmpArry[3];
        }

        public static int byteToInt(byte[] data)
        {
            return byteToInt(data, false);
        }

        #endregion

        #region ISmartCardReaderContactless Members

        public override byte[] getFirmwareVersion()
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x18;
                apduCommand.data[4] = 0x00;

                sendCardControl();

                if (apduCommand.response == null || apduCommand.response.Length < 6)
                    throw new ReaderException("Unable to get firmware version", apduCommand.response);

                return apduCommand.response.Skip(5).Take(apduCommand.response.Length - 5).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setLEDControl(byte setLEDStatus)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[6];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x29;
                apduCommand.data[4] = 0x01;

                // LED State
                apduCommand.data[5] = setLEDStatus;

                sendCardControl();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setBuzzerControl(byte setBuzzerStatus)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[6];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x28;
                apduCommand.data[4] = 0x01;

                // Buzzer Control
                apduCommand.data[5] = setBuzzerStatus;

                sendCardControl();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setBuzzerControl(byte setBuzzerRepeat, byte setBuzzerOn, byte setBuzzerOff)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[8];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x28;
                apduCommand.data[4] = 0x03;

                // Buzzer Control
                apduCommand.data[5] = setBuzzerRepeat;
                apduCommand.data[6] = setBuzzerOn;
                apduCommand.data[7] = setBuzzerOff;

                sendCardControl();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void setLEDBuzzerControl(byte setLEDBuzzerStatus)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[6];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x21;
                apduCommand.data[4] = 0x01;

                // Buzzer Control
                apduCommand.data[5] = setLEDBuzzerStatus;

                sendCardControl();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte readLEDBuzzerBehavior()
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x21;
                apduCommand.data[4] = 0x00;

                sendCardControl();

                return apduCommand.response[5];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte setAutomaticPICCPolling(byte setAutomaticPICCPollingSetting)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[6];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x23;
                apduCommand.data[4] = 0x01;

                // Polling Setting
                apduCommand.data[5] = setAutomaticPICCPollingSetting;

                sendCardControl();

                return apduCommand.response[5];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte readAutomaticPICCPolling()
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x23;
                apduCommand.data[4] = 0x00;

                sendCardControl();

                return apduCommand.response[5];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte setPICCOperatingParameter(byte setPICCOperationParameter)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[6];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x20;
                apduCommand.data[4] = 0x01;

                // Operating Parameter
                apduCommand.data[5] = setPICCOperationParameter;

                sendCardControl();

                return apduCommand.response[5];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte readPICCOperatingParameter()
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x20;
                apduCommand.data[4] = 0x00;

                sendCardControl();

                return apduCommand.response[5];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] setAutoPPS(byte setMaxSpeed)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[6];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x24;
                apduCommand.data[4] = 0x01;

                // Operating Parameter
                apduCommand.data[5] = setMaxSpeed;

                sendCardControl();

                return apduCommand.response.Skip(5).Take(apduCommand.response.Length - 5).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] readAutoPPS()
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x24;
                apduCommand.data[4] = 0x00;

                sendCardControl();

                return apduCommand.response.Skip(5).Take(apduCommand.response.Length - 5).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte setAntennaFieldControl(byte setAntennaFieldSetting)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[6];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x25;
                apduCommand.data[4] = 0x01;

                // Antenna Field Control Status
                apduCommand.data[5] = setAntennaFieldSetting;

                sendCardControl();

                return apduCommand.response[5];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte readAntennaFieldStatus()
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x25;
                apduCommand.data[4] = 0x00;

                sendCardControl();

                return apduCommand.response[5];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] ClearLCD()
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xFF;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x60;

                // RFU
                apduCommand.data[3] = 0x00;
                apduCommand.data[4] = 0x00;

                sendCardControl();

                return apduCommand.response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] LCDCharacterDisplay(byte LCDPosition, byte[] LCDMessage)
        {
            if (LCDMessage.Length > 16)
                throw new Exception("Length of message exceeds the maximum limit.");

            int iMaxLength = 16;
            int iActualLength = 0;

            iMaxLength = iMaxLength - int.Parse(string.Format("{0:X2}", LCDPosition)[1].ToString(), System.Globalization.NumberStyles.HexNumber);

            if (LCDMessage.Length > iMaxLength)
                iActualLength = iMaxLength;
            else
                iActualLength = LCDMessage.Length;

            if (iActualLength == 2)
                throw new Exception("Data length of two is not recommended.");

            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5 + iActualLength];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xFF;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x68;

                // RFU
                apduCommand.data[3] = LCDPosition;
                apduCommand.data[4] = (byte)iActualLength;

                for (int iCounter = 0; iCounter < iActualLength; iCounter++)
                {
                    apduCommand.data[iCounter + 5] = LCDMessage[iCounter];
                }

                sendCardControl();

                return apduCommand.response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] LCDGraphicDisplay(byte LineIndex, byte[] PixelData)
        {
            if (PixelData.Length > 128)
                throw new Exception("Length of data exceeds the maximum limit.");

            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5 + PixelData.Length];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xFF;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x6A;

                // RFU
                apduCommand.data[3] = LineIndex;
                apduCommand.data[4] = (byte)PixelData.Length;

                for (int iCounter = 0; iCounter < PixelData.Length; iCounter++)
                {
                    apduCommand.data[iCounter + 5] = PixelData[iCounter];
                }

                sendCardControl();

                return apduCommand.response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] LCDBacklightControl(byte BacklightControlSetting)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xFF;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x64;

                // RFU
                apduCommand.data[3] = BacklightControlSetting;
                apduCommand.data[4] = 0x00;

                sendCardControl();

                return apduCommand.response;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte setRTCOutputFormat(byte FormatSetting)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[6];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x55;
                apduCommand.data[4] = 0x01;

                // RTC Format
                apduCommand.data[5] = FormatSetting;

                sendCardControl();

                return apduCommand.response[5];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte getRTCOutputFormat()
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x55;
                apduCommand.data[4] = 0x00;

                sendCardControl();

                return apduCommand.response[5];
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] setRTCTimeStamp(int iYear, int iMonth, int iDay, int iHour, int iMinute, int iSecond)
        {
            if ((iMonth > 12) || (iDay > 31) || (iHour > 23) || (iMinute > 59) || (iSecond > 59))
                throw new Exception("Invalid date or time format.");

            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[12];

            byte[] TimeStampYear = new byte[4];
            TimeStampYear = intToByte(iYear);

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x56;
                apduCommand.data[4] = 0x07;

                apduCommand.data[5] = TimeStampYear[2];
                apduCommand.data[6] = TimeStampYear[3];
                apduCommand.data[7] = (byte)iMonth;
                apduCommand.data[8] = (byte)iDay;
                apduCommand.data[9] = (byte)iHour;
                apduCommand.data[10] = (byte)iMinute;
                apduCommand.data[11] = (byte)iSecond;

                sendCardControl();

                return apduCommand.response.Skip(5).Take(apduCommand.response.Length - 5).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public int[] getRTCTimeStamp()
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[5];

            byte[] TimeStampYear = new byte[4] { 0x00, 0x00, 0x00, 0x00 };
            int[] iReturnData = new int[6];
            int iTimeStampYear = 0;

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x56;
                apduCommand.data[4] = 0x00;

                sendCardControl();

                TimeStampYear[2] = apduCommand.response[5];
                TimeStampYear[3] = apduCommand.response[5 + 1];
                iTimeStampYear = byteToInt(TimeStampYear);

                iReturnData[0] = iTimeStampYear;
                for (int iCounter = 1; iCounter < 6; iCounter++)
                {
                    iReturnData[iCounter] = (int)apduCommand.response[5 + iCounter + 1];
                }

                return iReturnData;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public byte[] writeEEPROM(int iEEPROMAddress, byte[] Data)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[9 + Data.Length];
            byte[] EEPROMAddress = new byte[4];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x60;
                apduCommand.data[4] = (byte)(Data.Length + 4);

                EEPROMAddress = intToByte(iEEPROMAddress);

                for (int iCounter = 0; iCounter < 4; iCounter++)
                {
                    apduCommand.data[iCounter + 5] = EEPROMAddress[iCounter];
                }

                for (int iCounter = 0; iCounter < Data.Length; iCounter++)
                {
                    apduCommand.data[iCounter + 9] = Data[iCounter];
                }

                sendCardControl();

                return apduCommand.response.Skip(5).Take(apduCommand.response.Length - 5).ToArray();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public string readEEPROM(int iEEPROMAddress, byte DataLength)
        {
            apduCommand = new Apdu();
            apduCommand.lengthExpected = 255;
            apduCommand.data = new byte[10];
            byte[] EEPROMAddress = new byte[4];

            try
            {
                // Command Code
                apduCommand.data[0] = 0xE0;

                // Command Length
                apduCommand.data[1] = 0x00;
                apduCommand.data[2] = 0x00;

                // RFU
                apduCommand.data[3] = 0x61;
                apduCommand.data[4] = 0x05;

                EEPROMAddress = intToByte(iEEPROMAddress);

                for (int iCounter = 0; iCounter < 4; iCounter++)
                {
                    apduCommand.data[iCounter + 5] = EEPROMAddress[iCounter];
                }

                apduCommand.data[9] = DataLength;

                sendCardControl();

                return System.Text.Encoding.ASCII.GetString(apduCommand.response.Skip(5).Take(apduCommand.response.Length - 5).ToArray());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //public byte[] setSerialParameter(int iBaudRate, int iWordLength, int iParity, int iStopBits)
        //{
        //    byte[] SendData = new byte[12];
        //    byte[] ReceiveData;
        //    int ReceiveLen;
        //    byte[] ReturnData = new byte[2];
        //    byte[] WordLength = new byte[4];

        //    SendData[0] = 0xE0;
        //    SendData[1] = 0x00;
        //    SendData[2] = 0x00;
        //    SendData[3] = 0x65;
        //    SendData[4] = 0x07;

        //    WordLength = intToByte(iBaudRate);
        //    SendData[5] = WordLength[0];
        //    SendData[6] = WordLength[1];
        //    SendData[7] = WordLength[2];
        //    SendData[8] = WordLength[3];

        //    SendData[9] = (byte)iWordLength;
        //    SendData[10] = (byte)iParity;
        //    SendData[11] = (byte)iStopBits;

        //    try
        //    {
        //        //sendControlCommandBaudRate(SlotNumber.PICC, SendData.Length, SendData, iBaudRate, iParity, iWordLength, iStopBits);
        //        //sendControlCommand(SlotNumber.PICC, SendData.Length, SendData, out ReceiveLen, out ReceiveData);
        //        ReturnData[0] = ReceiveData[5];
        //        ReturnData[1] = ReceiveData[6];
        //        return ReturnData;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //}

        #endregion
    }
}
