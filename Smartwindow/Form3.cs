using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SmartWindowApp
{
    public partial class Form3 : Form
    {
        SerialPort serialPort;

        public Form3()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort("COM3", 9600); // 아두이노가 연결된 COM 포트 번호로 변경하세요.
            serialPort.DataReceived += SerialPort_DataReceived;
            serialPort.Open();
        }

        private void SerialPort_DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            string data = serialPort.ReadLine(); // 아두이노로부터 한 줄의 데이터를 읽음
            ProcessSensorData(data); // 데이터 처리 메서드 호출
        }

        private void ProcessSensorData(string data)
        {
            string[] sensorData = data.Split(','); // 쉼표를 기준으로 데이터 분리
            foreach (string item in sensorData)
            {
                string[] keyValue = item.Split(':'); // 콜론을 기준으로 키와 값 분리
                string key = keyValue[0];
                string value = keyValue[1];
                if (key == "T") // 온도 데이터
                {
                    double temperature = double.Parse(value);
                    MessageBox.Show("현재 온도: " + temperature + "°C");
                }
                else if (key == "H") // 습도 데이터
                {
                    double humidity = double.Parse(value);
                    MessageBox.Show("현재 습도: " + humidity + "%");
                }
                else if (key == "CO2") // 이산화탄소 농도 데이터
                {
                    double co2Level = double.Parse(value);
                    MessageBox.Show("현재 이산화탄소 농도: " + co2Level + "ppm");
                }
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}

