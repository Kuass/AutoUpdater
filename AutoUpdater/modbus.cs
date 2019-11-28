using System;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Ats;
using Ats.Comm;

using AutoUpdater;

namespace ProtocolModbus
{
    class Modbus
    {
        private DeviceCommon myDevice = new DeviceCommon();
        private ProtocolModbusClient myProtocol = new ProtocolModbusClient();

        public static int nDeviceType = 0; // Serial : 0, TCP/IP : 1
        public static string sTcpIP = "127.0.0.1";
        public static int nTcpPort = 502;
        public static string sComPort = "COM4";
        public static int nComBaud = 115200;
        public static bool bUseTcpHeader = false;

        protected static Modbus mModbus = null;

        public static Modbus getModbus()
        {
            if (mModbus == null)
            {
                mModbus = new Modbus();
            }
            return mModbus;
        }

        public void InitDevice()
        {
            Main.getClass().Textbox("ProtocolModbus InitStatus Reset...");
            myDevice.UnInit();
            Main.getClass().Textbox("ProtocolModbus InitDevice...");
            myProtocol.bUseHeader = bUseTcpHeader;

            if (nDeviceType == 1)
            {
                DeviceTcp device = new DeviceTcp();
                device.Init(myProtocol, sTcpIP, nTcpPort);
                myDevice = device;
            }
            else
            {
                Main.getClass().Textbox("GetDevice Information for " + myProtocol + ", " + sComPort + ", " + nComBaud + ".");
                DeviceSerial device = new DeviceSerial();
                device.Init(myProtocol, sComPort, nComBaud);
                myDevice = device;
            }

            string Text = myDevice.Connected ? "Connected" : "Disconnected";
            Main.getClass().Textbox(Text);
            Main.getClass().Textbox(myDevice.GetInfoString());

            ModbusReadHolding(0, 0, 10);
        }

        public void UnInitDevice()
        {
            Main.getClass().Textbox("ProtocolModbus UnInitDevice...");
            myDevice.UnInit();

            string Text = myDevice.Connected ? "Connected" : "Disconnected";
            Main.getClass().Textbox(Text);
        }

        public void ModbusReadHolding(int station, int address, int count)
        {
            /*
            station : 읽을 장치의 스테이션
            address : 읽을 장치의 시작주소
            count : 읽을 크기
             */
            if (!CheckConnectedAndMessage()) return;

            //int address = Convert.ToInt32(numericUpDownAddress.Value);
            //int count = Convert.ToInt32(numericUpDownCount.Value);

            EnumProtocolReturnCode retn = myProtocol.Func03(0, address, count); // OK=정상, Waiting=아직통신중, Error=오류발생, ErrorTimeOut=시간초과오류

            if (retn == EnumProtocolReturnCode.OK)
            {
                if (myProtocol.ReturnData.GetType() == typeof(byte[]))
                {
                    byte[] data = (byte[])myProtocol.ReturnData;
                    string buf = "Data = ";

                    for (int i = 0; i < data.Length; i++)
                    {
                        buf += String.Format("{0:X03} ", data[i]);
                    }
                    Main.getClass().Textbox(buf);
                }
                else
                {
                    Main.getClass().Textbox(myProtocol.ReturnData.ToString());
                }
            }
            else
            {
                Main.getClass().Textbox(myProtocol.sErrorMessage);
            }
        }

        private bool CheckConnectedAndMessage()
        {
            if (!myDevice.Connected)
            {
                Main.getClass().Textbox("Device is not connected.");
                return false;
            }

            return true;
        }

        public String generateWritePacket(int slaveAddress, long registerAddress, long value)
        {
            int lrc = 0;
            int sum1, sum2, sum3, sum4, sum5, sum6;
            //String packet = ":";
            String packet = "0X02";

            packet = packet + slaveAddress.ToString("X2") + "06" + registerAddress.ToString("X4") + value.ToString("X4");
            String sub1 = packet.Substring(1, 2); sum1 = Convert.ToInt16(sub1, 16);
            String sub2 = packet.Substring(3, 2); sum2 = Convert.ToInt16(sub2, 16);

            String sub3 = packet.Substring(5, 2); sum3 = Convert.ToInt16(sub3, 16);
            String sub4 = packet.Substring(7, 2); sum4 = Convert.ToInt16(sub4, 16);

            String sub5 = packet.Substring(9, 2); sum5 = Convert.ToInt16(sub5, 16);
            String sub6 = packet.Substring(11, 2); sum6 = Convert.ToInt16(sub6, 16);

            //// Longitudinal redundancy check Caclulation
            lrc = sum1 + sum2 + sum3 + sum4 + sum5 + sum6; //slaveAddress + registerAddress + value;
            lrc = ~lrc; // NOT
            lrc = lrc + 1;

            String Output = packet + lrc.ToString("X2").Substring(6, 2) + "\r\n";

            return Output;
        }

        public String generateReadPacket(int slaveAddress, long registerAddress, long numberOfRegistersToRead)
        {
            long value = 1;
            value = numberOfRegistersToRead;
            int lrc = 0;
            int sum1, sum2, sum3, sum4, sum5, sum6;
            String packet = ":";

            packet = packet + slaveAddress.ToString("X2") + "03" + registerAddress.ToString("X4") + value.ToString("X4");
            String sub1 = packet.Substring(1, 2); sum1 = Convert.ToInt16(sub1, 16);// int.TryParse(sub1, out sum1);
            String sub2 = packet.Substring(3, 2); sum2 = Convert.ToInt16(sub2, 16);

            String sub3 = packet.Substring(5, 2); sum3 = Convert.ToInt16(sub3, 16);
            String sub4 = packet.Substring(7, 2); sum4 = Convert.ToInt16(sub4, 16);

            String sub5 = packet.Substring(9, 2); sum5 = Convert.ToInt16(sub5, 16);
            String sub6 = packet.Substring(11, 2); sum6 = Convert.ToInt16(sub6, 16);

            //// Longitudinal redundancy check Caclulation
            lrc = sum1 + sum2 + sum3 + sum4 + sum5 + sum6; //slaveAddress + registerAddress + value;
            lrc = ~lrc; // NOT
            lrc = lrc + 1;

            String Output = packet + lrc.ToString("X2").Substring(6, 2) + "\r\n";
            return Output;
        }
    }
}
