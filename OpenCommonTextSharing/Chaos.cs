using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;

namespace OpenCommonTextSharing
{
    public static class Chaos
    {
        public static byte[] Encrypt(byte[] data, double u, double x0)
        {
            byte[] res = new byte[data.Length];
            double x = logistic(u, x0, 2000);

            for (int i = 0; i < data.Length; i++)
            {
                x = logistic(u, x, 5);
                res[i] = Convert.ToByte(Convert.ToInt32(Math.Floor(x * 1000)) % 256 ^ data[i]);//取x小数点后3位来生成密钥
            }

            return res;
        }

        private static double logistic(double u, double x, int n)
        {
            for (int i = 0; i < n; i++)
            {
                x = u * x * (1 - x);
            }
            return x;
        }

    }
}
