namespace Ostov
{
    public class Set
    {
        int[] parent;
        int[] rank;

        public Set(int length) //операции объединения и поиска
        {
            parent = new int[length];
            rank = new int[length];

            for (int i = 0; i < parent.Length; i++)
            {
                parent[i] = i;
            }
        }

        public void MakeSet(int x) //создает набор их х
        {
            parent[x] = x;
            rank[x] = 0;
        }

        public void Union(int x, int y) //объединяет два набора х и у, если они не один набор
        {
            int representativeX = FindSet(x);
            int representativeY = FindSet(y);

            if (rank[representativeX] == rank[representativeY])
            {
                rank[representativeY]++;
                parent[representativeX] = representativeY;
            }

            else if (rank[representativeX] > rank[representativeY])
            {
                parent[representativeY] = representativeX;
            }
            else
            {
                parent[representativeX] = representativeY;
            }
        }

        public int FindSet(int x)// ищет набор с x
        {
            if (parent[x] != x)
            {
                parent[x] = FindSet(parent[x]);
            }

            return parent[x];
        }

        
    }
}