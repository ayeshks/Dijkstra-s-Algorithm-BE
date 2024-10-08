using DijkstrasAlgorithm.Models;
using DijkstrasAlgorithm.Services;
using Microsoft.AspNetCore.Mvc;

namespace DijkstrasAlgorithm.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShortestPathController : ControllerBase
    {
        private readonly ShortestPathCalculator _calculator = new ShortestPathCalculator();

        [HttpGet]
        public ActionResult<string> GetShortestPath(string fromNode, string toNode)
        {
            var graph = Graph.GetGraph();
            var result = _calculator.CalculateShortestPath(fromNode, toNode, graph);

            // Prepare output in desired format
            string output = $"fromNodeName = \"{fromNode}\", toNodeName = \"{toNode}\": {string.Join(", ", result.NodeNames)}\n" +
                            $"Total Distance: {result.Distance}";

            return Ok(output);
        }
    }


}

