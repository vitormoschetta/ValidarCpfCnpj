using System;

namespace ValidarCpfCnpj
{
    public class Validar
    {
        public bool ValidarCpfCnpj(string parametro)
        {
            var doc = parametro.Replace(".", "").Replace("-", "").Replace("/", "").Trim();

            if (doc.Length != 11 && doc.Length != 14)
                return false;

            if (ExisteCaractereAlfabetico(doc))
                return false;

            if (TodosCaractersIguais(doc))
                return false;

            bool valido = false;

            if (doc.Length == 11)
                valido = ValidarCpf(doc);

            if (doc.Length == 14)
                valido = ValidarCpfCnpj(doc);

            return valido;
        }

        private bool TodosCaractersIguais(string doc)
        {
            char[] arr = doc.ToCharArray();
            char caractere = 'x';
            for (int i = 0; i < arr.Length; i++)
            {
                if (i == 0)
                    caractere = arr[i];
                else
                {
                    if (caractere == arr[i])
                        caractere = arr[i];
                    else
                        return false;
                }

            }
            return true;
        }

        private bool ExisteCaractereAlfabetico(string doc)
        {
            if (doc.Contains(@"^[a-z"))
                return true;

            return false;
        }


        private bool ValidarCpf(string doc)
        {
            // validar primeiro digito
            var noveNumeros = doc.Substring(0, 9);
            var acc = 0;
            var j = 10;
            for (var i = 0; i < noveNumeros.Length; i++)
            {
                var digito = Convert.ToInt32(noveNumeros.Substring(i, 1));
                acc += digito * j;
                j--;
            }

            var resto = acc % 11;
            var verifica = 11 - resto;
            var verificador = 0;
            if (verifica < 10)
                verificador = verifica;


            if (Convert.ToInt32(doc.Substring(9, 1)) != verificador)
                return false;


            // validar segundo digito
            var dezNumeros = doc.Substring(0, 10);
            acc = 0;
            j = 11;
            for (var i = 0; i < dezNumeros.Length; i++)
            {
                var digito = Convert.ToInt32(dezNumeros.Substring(i, 1));
                acc += digito * j;
                j--;
            }

            resto = acc % 11;
            verifica = 11 - resto;
            verificador = 0;
            if (verifica < 10)
                verificador = verifica;

            if (Convert.ToInt32(doc.Substring(10, 1)) != verificador)
                return false;

            return true;
        }

        private bool ValidarCnpj(string doc)
        {
            // validar primeiro digito
            var dozeNumeros = doc.Substring(0, 12);
            var numerosInverso = InverteString(dozeNumeros);

            var acc = 0;
            var j = 2;
            for (var i = 0; i < numerosInverso.Length; i++)
            {
                var digito = Convert.ToInt32(numerosInverso.Substring(i, 1));
                acc += digito * j;
                j++;

                if (j > 9)
                    j = 2;
            }

            var resto = acc % 11;
            var verifica = 11 - resto;
            var verificador = 0;
            if (verifica < 10)
                verificador = verifica;


            if (Convert.ToInt32(doc.Substring(12, 1)) != verificador)
                return false;


            // validar segundo digito     
            var trezeNumeros = doc.Substring(0, 13);
            numerosInverso = InverteString(trezeNumeros);

            acc = 0;
            j = 2;
            for (var i = 0; i < numerosInverso.Length; i++)
            {
                var digito = Convert.ToInt32(numerosInverso.Substring(i, 1));
                acc += digito * j;
                j++;

                if (j > 9)
                    j = 2;
            }

            resto = acc % 11;
            verifica = 11 - resto;
            verificador = 0;
            if (verifica < 10)
                verificador = verifica;


            if (Convert.ToInt32(doc.Substring(13, 1)) != verificador)
                return false;

            return true;
        }

        private string InverteString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}