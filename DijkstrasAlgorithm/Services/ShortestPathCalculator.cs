using DijkstrasAlgorithm.Models;

namespace DijkstrasAlgorithm.Services
{
    public class ShortestPathCalculator
    {
        public ShortestPathData CalculateShortestPath(string fromNodeName, string toNodeName, List<Node> graph)
        {
            var startNode = graph.FirstOrDefault(n => n.Name == fromNodeName);
            var endNode = graph.FirstOrDefault(n => n.Name == toNodeName);

            if (startNode == null || endNode == null)
                throw new Exception("Invalid start or end node");

            var distances = new Dictionary<Node, int>();
            var previousNodes = new Dictionary<Node, Node>();
            var unvisitedNodes = new HashSet<Node>(graph);

            foreach (var node in graph)
                distances[node] = int.MaxValue;

            distances[startNode] = 0;

            while (unvisitedNodes.Any())
            {
                var currentNode = unvisitedNodes.OrderBy(n => distances[n]).First();
                unvisitedNodes.Remove(currentNode);

                if (currentNode == endNode) break;

                foreach (var neighbor in currentNode.Neighbors)
                {
                    var distance = distances[currentNode] + neighbor.Value;
                    if (distance < distances[neighbor.Key])
                    {
                        distances[neighbor.Key] = distance;
                        previousNodes[neighbor.Key] = currentNode;
                    }
                }
            }

     
            var path = new List<string>();
            var totalDistance = distances[endNode];
            var nodeToTrace = endNode;

            while (nodeToTrace != null)
            {
                path.Insert(0, nodeToTrace.Name);
                previousNodes.TryGetValue(nodeToTrace, out nodeToTrace);
            }

            return new ShortestPathData
            {
                NodeNames = path,
                Distance = totalDistance
            };
        }
    }

}
