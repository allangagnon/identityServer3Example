using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;

namespace ExampleSrv
{
    public static class Cert
    {
        public static X509Certificate2 Load()
        {
            string _certPath = @"S:\src\SandBox\ExampleApp\ExampleSrv\bin\Certs\idsrv3test.pfx";
            return new X509Certificate2(_certPath, "idsrv3test");
        }
    }
}