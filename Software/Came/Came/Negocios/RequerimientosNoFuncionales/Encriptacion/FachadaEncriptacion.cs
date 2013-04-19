using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Came.Negocios.RequerimientosNoFuncionales.Interfaces;

namespace Came.Negocios.RequerimientosNoFuncionales.Encriptacion
{
    class FachadaEncriptacion : ICrypto
    {
        private string key;
        Encrypter encriptacion;

        public FachadaEncriptacion(string key)
        {
            this.key = key;
            encriptacion = new Encrypter();
        }

        public string Encriptar(string text, string password)
        {
            return Encrypter.Encrypt(text, password);
        }

        public string Desencriptar(string encrypted, string password)
        {
           
            return Encrypter.Decrypt(encrypted, password);
        }
    }
}
