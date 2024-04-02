var coord = new Coords(0, 0, 0);
// List<string> directions = new List<string> { "ne", "sw" };

var lines = File.ReadAllLines("input/input.txt");

foreach (string line in lines)
{
    var directions = line.Split(",");
    foreach (string direction in directions)
    {
        coord.Move(direction);
        coord.CalculateDistance();
    }
    Console.WriteLine(coord.maxDistance);
}

public struct Coords
{
    public Coords(int q, int r, int s)
    {
        Q = q;
        R = r;
        S = s;
    }

    public int Q { get; set; }
    public int R { get; set; }
    public int S { get; set; }

    public int maxDistance = 0;

    public void CalculateDistance()
    {
        List<int> directionalList = new List<int> {
            Math.Abs(this.Q),
            Math.Abs(this.R),
            Math.Abs(this.S)
        };
        if (directionalList.Max() > maxDistance)
        {
            maxDistance = directionalList.Max();
        }
    }

    public void Move(string direction)
    {
        if (direction == "n")
        {
            this.R -= 1;
            this.S += 1;
        }
        if (direction == "s")
        {
            this.R += 1;
            this.S -= 1;
        }
        if (direction == "ne")
        {
            this.R -= 1;
            this.Q += 1;
        }
        if (direction == "se")
        {
            this.Q += 1;
            this.S -= 1;
        }
        if (direction == "nw")
        {
            this.S += 1;
            this.Q -= 1;
        }
        if (direction == "sw")
        {
            this.Q -= 1;
            this.R += 1;
        }
    }


}

