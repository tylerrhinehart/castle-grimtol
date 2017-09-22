using System.Collections.Generic;

namespace CastleGrimtol.Project
{
    public interface IMoveable
    {
        bool CanMove { get; set; }
        string MustDo { get; set; }
        string HaveDone { get; set; }
    }
}