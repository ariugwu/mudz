using Mudz.Common.Domain.Environment;

namespace Mudz.Data.Domain.Environment.Model
{
    public class Grid
    {
        public int[][] Sheet { get; set; }

        public IRoomCollection Rooms { get; set; }
    }
}
