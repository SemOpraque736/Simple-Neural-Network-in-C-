using System;

class Program
{
    static void Main(string[] args)
    {
        float saida = 0;
        Random random = new Random();
        var epochs = 200;
        var LR = 0.0008f;
        int[] entradas = new int[3];
        for (int i = 0; i < entradas.Length; i++)
        {
            entradas[i] = random.Next(0, 3);
        }
        int[] saidas = new int[3];
        for (int i = 0; i < saidas.Length; i++)
        {
            saidas[i] = random.Next(0, 3);
        }
        float[] pesos = new float[8];
        for (int i = 0; i < pesos.Length; i++)
        {
            pesos[i] = (float)(random.NextDouble() * -0.1 - 0.1);
            Console.WriteLine("Peso " + (i + 1) + ": " + pesos[i]);
        }
        float b1 = (float)(random.NextDouble() * -0.1 - 0.1);
        for (int epoch = 0; epoch < epochs; epoch++)
        {
            int Escolhido = random.Next(0, entradas.Length);
            int input = entradas[Escolhido];
            Escolhido = random.Next(0, saidas.Length);
            int target = saidas[Escolhido];
            saida = 0;
            float erro = 0;
            for (int Forward = 0; Forward < pesos.Length; Forward++)
            {
                saida += pesos[Forward] * input;
            }
            saida += b1;
            erro = target - saida;
            for (int p = 0; p < pesos.Length; p++)
            {
                pesos[p] += (float)LR * erro * input;
                b1 += (float)LR * erro;
            }
            Console.WriteLine($"Epoch: {epoch + 1}, Input: {input}, Target: {target}, OutPut: {saida}, Error: {erro}");

        }
        for (int i = 0; i < pesos.Length; i++)
        {
            Console.WriteLine("Peso " + (i + 1) + ": " + pesos[i]);
        }
    }
}
