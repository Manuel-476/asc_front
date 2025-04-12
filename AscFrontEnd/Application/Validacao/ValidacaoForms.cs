using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AscFrontEnd.Application.Validacao
{

        public static class ValidacaoForms
        {
        private static bool _processando = false;

        // Método KeyPress: aceita vírgula
        public static void TratarKeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            if (char.IsControl(e.KeyChar)) // Permite backspace, etc.
            {
                e.Handled = false;
                return;
            }

            // Aceita números e vírgula
            if (char.IsDigit(e.KeyChar) || e.KeyChar == ',')
            {
                if (e.KeyChar == ',' && textBox.Text.Contains(","))
                {
                    e.Handled = true; // Impede múltiplas vírgulas
                }
                else
                {
                    e.Handled = false; // Aceita vírgula
                }
            }
            else
            {
                e.Handled = true; // Bloqueia outros caracteres
            }
        }

        // Método TextChanged: formata sem apagar com vírgula
        public static void TratarTextChanged(object sender, EventArgs e)
        {
            if (_processando) return;

            TextBox textBox = sender as TextBox;
            if (textBox == null) return;

            bool permitirAte100 = textBox.Name == "descontoTxt";
            string texto = textBox.Text.Trim();

            if (string.IsNullOrEmpty(texto))
            {
                return; // Permite campo vazio
            }

            _processando = true;
            try
            {
                int posCursor = textBox.SelectionStart;
                bool temDecimal = texto.Contains(",");

                // Se só tiver vírgula, aceita como início de decimal
                if (texto == ",")
                {
                    textBox.Text = "0,";
                    textBox.SelectionStart = 2;
                    return;
                }

                string normalizado = texto.Replace(".", "").Replace(",", ".");
                if (float.TryParse(normalizado, out float valor))
                {
                    bool valido = permitirAte100 ? (valor >= 0 && valor <= 100) : (valor > 0);
                    if (valido)
                    {
                        string textoFormatado = valor.ToString(
                            temDecimal ? "N2" : "N0",
                            System.Globalization.CultureInfo.GetCultureInfo("pt-BR")
                        );

                        int diferenca = textoFormatado.Length - texto.Length;
                        int novaPos = posCursor + diferenca;
                        if (novaPos < 0) novaPos = 0;
                        if (novaPos > textoFormatado.Length) novaPos = textoFormatado.Length;

                        textBox.Text = textoFormatado;
                        textBox.SelectionStart = novaPos;
                    }
                    else
                    {
                        textBox.Text = texto.Length > 1 ? texto.Substring(0, texto.Length - 1) : "";
                        textBox.SelectionStart = textBox.Text.Length;
                    }
                }
                else if (temDecimal)
                {
                    // Aceita texto com vírgula sem apagar tudo
                    return; // Mantém o texto como está até completar o número
                }
                else
                {
                    textBox.Text = texto.Length > 1 ? texto.Substring(0, texto.Length - 1) : "";
                    textBox.SelectionStart = textBox.Text.Length;
                }
            }
            finally
            {
                _processando = false;
            }
        }
        public static void TratarLeave(object sender, EventArgs e)
        {
            var textBox = sender as TextBox;
            if (textBox == null) return;

            bool permitirAte100 = textBox.Name == "descontoTxt";
            string texto = textBox.Text;

            string semFormatacao = texto.Replace(".", "").Replace(",", ".");

            if (decimal.TryParse(semFormatacao, System.Globalization.NumberStyles.Any,
                                 System.Globalization.CultureInfo.InvariantCulture, out decimal valor))
            {
                bool valido = permitirAte100 ? valor >= 0 && valor <= 100 : valor > 0;

                if (valido)
                {
                    textBox.Text = valor.ToString("N2", System.Globalization.CultureInfo.GetCultureInfo("pt-BR"));
                }
                else
                {
                    textBox.Text = permitirAte100 ? "0,00" : "";
                }
            }
            else
            {
                textBox.Text = permitirAte100 ? "0,00" : "";
            }
        }



        // Métodos de validação ajustados
        public static bool IsPositiveFloat(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return true; // Permite apagar

            valor = valor.Replace(",", ".");
            bool podeConverter = float.TryParse(valor, System.Globalization.NumberStyles.Any,
                                                System.Globalization.CultureInfo.InvariantCulture, out float resultado);

            return podeConverter && (resultado > 0 || valor == "0" || valor.StartsWith("0.") || valor == ".");
        }

        public static bool IsPositiveFloatDesconto(string valor)
        {
            if (string.IsNullOrWhiteSpace(valor))
                return true; // Permite apagar

            valor = valor.Replace(",", ".");
            bool podeConverter = float.TryParse(valor, System.Globalization.NumberStyles.Any,
                                                System.Globalization.CultureInfo.InvariantCulture, out float resultado);

            return podeConverter && (resultado >= 0 && resultado <= 100 || valor == "0" || valor.StartsWith("0.") || valor == ".");
        }
        public static void FormatarTextoComMilhar(object sender)
        {
            TextBox textBox = (TextBox)sender;
            string texto = textBox.Text.Replace(".", "").Replace(",", ".");

            if (float.TryParse(texto, System.Globalization.NumberStyles.Any,
                               System.Globalization.CultureInfo.InvariantCulture, out float valor))
            {
                // Ex: 1.234,56
                string textoFormatado = valor.ToString("#,##0.##",
                    System.Globalization.CultureInfo.CreateSpecificCulture("pt-BR"));
                textBox.Text = textoFormatado;
            }
        }

        public static bool IsValidEmail(string email)
        {
            try
            {
                var emailAdress = new MailAddress(email);
            }
            catch
            {

                return false;
            }

            return true;
        }

        public static bool IsValidNif(string nif)
        {
            bool isValid = true;

            string regEx = @"\b\d{9}\w{2}\d{3}\b";

            isValid = Regex.IsMatch(nif, regEx);

            if (!isValid)
            {
                var regEx2 = @"[5,9]{1}[0-9]{9}";

                isValid = Regex.IsMatch(nif, regEx2);
            }

            return isValid;
        }

        public static bool IsValidPhone(string phone)
        {
            bool isValid = true;
            try
            {
                string regEx = @"[9]\d{8}";

                isValid = Regex.IsMatch(phone, regEx);
            }
            catch
            {

            }
            return isValid;
        }

    }
}
