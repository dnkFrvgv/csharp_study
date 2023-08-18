namespace Csharp_study.LeetCodeSolutions
{
    public class SimplifyPath
    {
        /* Medium
        * 
        * Problema:
        * 
        * Given a string path, which is an absolute path (starting with a slash '/') to a file
        * or directory in a Unix-style file system, convert it to the simplified canonical path.
        * In a Unix-style file system, a period '.' refers to the current directory, a double period
        * '..' refers to the directory up a level, and any multiple consecutive slashes (i.e. '//')
        * are treated as a single slash '/'. For this problem, any other format of periods such as '...'
        * are treated as file/directory names.
        * 
        * The canonical path should have the following format:
        * 
        * The path starts with a single slash '/'.
        * Any two directories are separated by a single slash '/'.
        * The path does not end with a trailing '/'.
        * The path only contains the directories on the path from the root directory to the target file
        * or directory (i.e., no period '.' or double period '..')
        * 
        * Return the simplified canonical path.
        * 
        * Example 1:
        * Input: path = "/home/"
        * Output: "/home"        
        */
        public static string Solution(string path)
        {
            // o objetivo é retornar o caminho absoluto de forma simplificada
            // para isso 


            // inicia lista vazia onde serão guardados os diretorios.
            // nesse caso esta lista tem um comportamento de uma pilha
            // pois é necessario saber os diretorios anteriores 
            // quando é usado o comando ".."
            List<String> directory = new List<string>();


            // os diretorios são separados por uma barra
            // então separa a string usando a barra como separador
            // e itera a lista que o metodo split retorna
            // que são os comandos do caminho
            foreach (string command in path.Split('/'))
            {
                // O "." é um comando que referencia o diretorio atual ex: ./
                if (command == ".")
                {
                    // então nada muda pois não é um diretorio nem arquivo
                    continue;
                }

                // O ".." significa que se quer retornar para o diretorio anterior
                if (command == "..")
                {
                    // então checa se na pilha tem um diretorio anterior
                    // ou seja, se a pilha não esta vazia
                    if (directory.Count != 0)
                    {
                        // se tem, removemos o ultimo diretorio andicionado da pilha
                        directory.RemoveAt(directory.Count - 1);
                    }

                    // se não tem diretorio anterior, então nada muda
                    continue;
                }

                // no caso de ter duas barras seguidas na string path ex: //
                // o metodo split retornaria uma string vazia: ""
                // então aqui checa se esse não é o caso
                if (command != "")
                {
                    // aqui se tem certeza que command é um diretorio ou arquivo
                    // então adiciona a lista de diretorios
                    directory.Add(command);
                }
            }

            // o caminho absoludo começa pelo root que é representado como /
            var root = "/";

            // aqui a lista é transformada em uma string separada por barras
            // e adicionada a variavel root, retornando o diretorio final.
            return root + String.Join("/", directory);
        }
    }
}

