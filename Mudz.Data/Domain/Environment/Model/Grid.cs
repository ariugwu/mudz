using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mudz.Data.Domain.Environment.Model
{
    public class Grid
    {
        public int[][] Sheet { get; set; }

        public RoomCollection Rooms { get; set; }
    }
}
