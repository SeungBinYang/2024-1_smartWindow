using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace SmartWindowApp
{
    public partial class Form2 : Form
    {
        SerialPort serialPort;

        public Form2()
        {
            InitializeComponent();
            InitializeSerialPort();
        }

        private void InitializeSerialPort()
        {
            serialPort = new SerialPort("COM3", 9600); // 아두이노가 연결된 COM 포트 번호로 변경하세요.
            serialPort.Open();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            // 폼 로드 시 필요한 초기화 작업을 여기에 추가할 수 있습니다.
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 창문 열기 명령
            serialPort.Write("O");
            MessageBox.Show("창문이 열렸습니다.");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // 창문 닫기 명령
            serialPort.Write("C");
            MessageBox.Show("창문이 닫혔습니다.");
        }
    }
}
