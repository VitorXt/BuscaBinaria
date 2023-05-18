using System;

class Program
{
    static int[] vetor = { 10, 20, 30, 40, 50, 60, 70, 80, 90 };

    static void Main(string[] args)
    {
        int opcao;

        do
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1 - Inserir no vetor");
            Console.WriteLine("2 - Buscar no vetor por busca binária");
            Console.WriteLine("3 - Buscar no vetor por busca sequencial");
            Console.WriteLine("4 - Sair");
            Console.Write("Escolha uma opção: ");

            if (int.TryParse(Console.ReadLine(), out opcao))
            {
                switch (opcao)
                {
                    case 1:
                        InserirNoVetor();
                        break;
                    case 2:
                        BuscarPorBuscaBinaria();
                        break;
                    case 3:
                        BuscarPorBuscaSequencial();
                        break;
                    case 4:
                        Console.WriteLine("Saindo...");
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Tente novamente.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Opção inválida. Tente novamente.");
            }

            Console.WriteLine();
        } while (opcao != 4);
    }

    static void InserirNoVetor()
    {
        Console.Write("Digite o valor a ser inserido: ");
        if (int.TryParse(Console.ReadLine(), out int valor))
        {
            if (Array.IndexOf(vetor, valor) != -1)
            {
                Console.WriteLine("O valor já existe no vetor. Não é possível inserir valores duplicados.");
            }
            else
            {
                Array.Resize(ref vetor, vetor.Length + 1);

                int posicaoInsercao = vetor.Length - 1;
                while (posicaoInsercao > 0 && vetor[posicaoInsercao - 1] > valor)
                {
                    vetor[posicaoInsercao] = vetor[posicaoInsercao - 1];
                    posicaoInsercao--;
                }

                vetor[posicaoInsercao] = valor;

                Console.WriteLine("Valor inserido no vetor com sucesso.");
            }
        }
        else
        {
            Console.WriteLine("Valor inválido. Tente novamente.");
        }
    }

    static void BuscarPorBuscaBinaria()
    {
        Console.Write("Digite o valor a ser buscado: ");
        if (int.TryParse(Console.ReadLine(), out int valor))
        {
            int indice = BuscaBinaria(vetor, valor);
            if (indice == -1)
            {
                Console.WriteLine("O valor {0} não foi encontrado.", valor);
            }
            else
            {
                Console.WriteLine("O valor {0} foi encontrado na posição {1}.", valor, indice);
            }
        }
        else
        {
            Console.WriteLine("Valor inválido. Tente novamente.");
        }
    }

    static void BuscarPorBuscaSequencial()
    {
        Console.Write("Digite o valor a ser buscado: ");
        if (int.TryParse(Console.ReadLine(), out int valor))
        {
            int indice = BuscaSequencial(vetor, valor);
            if (indice == -1)
            {
                Console.WriteLine("O valor {0} não foi encontrado.", valor);
            }
            else
            {
                Console.WriteLine("O valor {0} foi encontrado na posição {1}.", valor, indice);
            }
        }
        else
        {
            Console.WriteLine("Valor inválido. Tente novamente.");
        }
    }

    static int BuscaBinaria(int[] vetor, int valorBuscado)
    {
        int inicio = 0;
        int fim = vetor.Length - 1;

        while (inicio <= fim)
        {
            int meio = (inicio + fim) / 2;

            if (vetor[meio] == valorBuscado)
            {
                return meio;
            }
            else if (vetor[meio] < valorBuscado)
            {
                inicio = meio + 1;
            }
            else
            {
                fim = meio - 1;
            }
        }

        return -1;
    }

    static int BuscaSequencial(int[] vetor, int valorBuscado)
    {
        for (int i = 0; i < vetor.Length; i++)
        {
            if (vetor[i] == valorBuscado)
            {
                return i;
            }
        }

        return -1;
    }
}
