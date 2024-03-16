namespace Lab3_
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent(); //�������������� ��� ���������� ����� (������, ��������� ����..)
            this.Text = "����������� ������";
            this.ActiveControl = textBox1;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Calculate();
        }

        private void Calculate()
        {
            try
            {
                string input1 = textBox1.Text;
                string input2 = textBox2.Text;

                string[] parts1 = input1.Split('/');
                string[] parts2 = input2.Split('/');

                if (parts1.Length != 2 || parts2.Length != 2)
                {
                    throw new FormatException("����� ������ ���� � ������� '���������/�����������'");
                }

                int numerator1 = int.Parse(parts1[0]);
                int denominator1 = int.Parse(parts1[1]);

                int numerator2 = int.Parse(parts2[0]);
                int denominator2 = int.Parse(parts2[1]);

                //���� ������������ ���� ������������ ����� ��� ����������� ����� 0
                if (numerator1 > denominator1 || denominator1 == 0 || numerator2 > denominator2 || denominator2 == 0)
                {
                    throw new ArgumentException("������������ �������� ��������� � �����������");
                }

                if (numerator1 == denominator1 && numerator2 == denominator2)
                {
                    throw new ArgumentException("��������� � ����������� �� ����� ���� ����� � ������ ������. ������� ���������� �����");
                }

                var fraction1 = new Fraction(numerator1, denominator1).Simplify(); ;
                var fraction2 = new Fraction(numerator2, denominator2).Simplify(); ;

                // ��������� ������
                int comparisonResult = fraction1.CompareTo(fraction2);

                // ����� ���������� ���������
                if (comparisonResult < 0)
                {
                    label1.Text = "������ ����� ������ ������";
                }
                else if (comparisonResult > 0)
                {
                    label1.Text = "������ ����� ������ ������";
                }
                else
                {
                    label1.Text = "����� �����";
                }

                Fraction result = null;
                switch (comboBox1.Text)
                {
                    case "+":
                        result = fraction1.Add(fraction2);
                        break;
                    case "-":
                        result = fraction1.Subtract(fraction2);
                        break;
                    case "*":
                        result = fraction1.Multiply(fraction2);
                        break;
                    case "%":
                        result = fraction1.Divide(fraction2);
                        break;
                    default:
                        break;
                }

                if (result != null)
                {
                    textBox3.Text = result.ToString();
                    result.Simplify();
                }
            }
            catch (FormatException)
            {
                // ��������� ������������� �������
            }
            catch (ArgumentException ex)
            {
                MessageBox.Show(ex.Message, "������", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                textBox2.Focus();
            }
        }
    }
}
