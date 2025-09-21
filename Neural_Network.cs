using System;
using System.Runtime;
class Program
{
    static void Main(string[] args)
    {
        // define variaveis
        float saida = 0;
        // definindo o random
        Random random = new Random();
        var epochs = 200;
        var LR = 0.0008f;
        // definindo dados de entradas
        (int, int)[] entradas = new (int, int)[]
        {
            (0, 0),
            (0, 1),
            (1, 0),
            (1, 1),
        };
        // definindo dados de saidas
        int[] saidas = new int[]{
            0,
            1,
            1,
            0
        };
        // definindo pesos 1 e 2
        float[] pesos1 = new float[8];
        for (int i = 0; i < pesos1.Length; i++)
        {
            pesos1[i] = (float)(random.NextDouble() * -0.1 - 0.1);
            Console.WriteLine("Peso " + (i + 1) + ": " + pesos1[i]);
        }
        float[] pesos2 = new float[8];
        for (int i = 0; i < pesos2.Length; i++)
        {
            pesos2[i] = (float)(random.NextDouble() * -0.1 - 0.1);
            Console.WriteLine("Peso " + (i + 1) + ": " + pesos2[i]);
        }
        // definindo bias
        float b1 = (float)(random.NextDouble() * -0.1 - 0.1);
        // iniciando o treinamento
        var rodando = true;
        while (rodando)
        {
            for (int epoch = 0; epoch < epochs; epoch++)
            {
                int Escolhido = random.Next(0, entradas.Length);
                List<int> input = new List<int>
            {
                entradas[Escolhido].Item1,
                entradas[Escolhido].Item2
            };
                Console.WriteLine(input);
                Escolhido = random.Next(0, saidas.Length);
                int target = saidas[Escolhido];
                saida = 0;
                float erro = 0;
                for (int Forward = 0; Forward < pesos1.Length; Forward++)
                {
                    saida += pesos1[Forward] * input[0];
                }
                for (int Forward = 0; Forward < pesos2.Length; Forward++)
                {
                    saida += pesos2[Forward] * input[1];
                }
                saida += b1;
                erro = target - saida;
                for (int p = 0; p < pesos1.Length; p++)
                {
                    pesos1[p] += (float)LR * erro * input[0];
                    pesos1[p] += (float)LR * erro * input[1];
                }
                for (int p = 0; p < pesos2.Length; p++)
                {
                    pesos2[p] += (float)LR * erro * input[0];
                    pesos2[p] += (float)LR * erro * input[1];
                }
                b1 += (float)LR * erro;
                Console.WriteLine($"Epoch: {epoch + 1}, Input: ({input[0]}, {input[1]}), Target: {target}, OutPut: {saida}, Error: {erro}");
            }
        Console.WriteLine("Pesos Finais:");
        Console.WriteLine("Pesos da entrada 1:");
        for (int i = 0; i < pesos1.Length; i++)
        {
            Console.WriteLine("Peso " + (i + 1) + ": " + pesos1[i]);
        }
        Console.WriteLine("Pesos da entrada 2:");
        for (int i = 0; i < pesos2.Length; i++)
        {
            Console.WriteLine("Peso " + (i + 1) + ": " + pesos2[i]);
        }

        }
    }
}
