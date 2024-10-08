namespace DijkstrasAlgorithm.Models
{
    public static class Graph
    {
        public static List<Node> GetGraph()
        {
            // Create nodes
            var nodeA = new Node { Name = "A" };
            var nodeB = new Node { Name = "B" };
            var nodeC = new Node { Name = "C" };
            var nodeD = new Node { Name = "D" };
            var nodeE = new Node { Name = "E" };
            var nodeF = new Node { Name = "F" };
            var nodeG = new Node { Name = "G" };
            var nodeH = new Node { Name = "H" };
            var nodeI = new Node { Name = "I" };


            // From A
            nodeA.Neighbors[nodeB] = 4;
            nodeA.Neighbors[nodeC] = 6;

            // From B
            nodeB.Neighbors[nodeA] = 4;
            nodeB.Neighbors[nodeF] = 2;

            // From C
            nodeC.Neighbors[nodeD] = 8;
            nodeC.Neighbors[nodeA] = 6;

            // From D
            nodeD.Neighbors[nodeC] = 8;
            nodeD.Neighbors[nodeE] = 4;
            nodeD.Neighbors[nodeG] = 1;

            // From E
            nodeE.Neighbors[nodeD] = 4;
            nodeE.Neighbors[nodeF] = 3;
            nodeE.Neighbors[nodeI] = 8;

            // From F
            nodeF.Neighbors[nodeB] = 2;
            nodeF.Neighbors[nodeH] = 6;
            nodeF.Neighbors[nodeG] = 4;

            // From G
            nodeG.Neighbors[nodeD] = 1;
            nodeG.Neighbors[nodeF] = 4;
            nodeG.Neighbors[nodeI] = 5;
            nodeG.Neighbors[nodeH] = 5;

            // From H
            nodeH.Neighbors[nodeG] = 5;
            nodeH.Neighbors[nodeF] = 6;

            // Return the full graph
            return new List<Node> { nodeA, nodeB, nodeC, nodeD, nodeE, nodeF, nodeG, nodeH, nodeI };
        }
    }


}
