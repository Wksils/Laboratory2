interface Pair
{
    public Pair Plus(Pair pair);
    public Pair Minus(Pair pair);
    public Pair Multiply(Pair pair);
}
class FazzyNumber : Pair
{
    public double x { get; set; }
    public double e1 { get; set; }
    public double e2 { get; set; }

    public FazzyNumber(double x, double e1, double e2)
    {
        this.x = x;
        this.e1 = e1;
        this.e2 = e2;
    }

    public Pair Plus(Pair pair)
    {
        double ee1 = this.x + (pair as FazzyNumber)!.x - this.e1 - (pair as FazzyNumber)!.e1;
        double ee2 = this.x + (pair as FazzyNumber)!.x;
        double ee3 = this.x + (pair as FazzyNumber)!.x + this.e2 + (pair as FazzyNumber)!.e2;
        return new FazzyNumber(ee1, ee2, ee3) as Pair;
    }

    public Pair Minus(Pair pair)
    {
        double ee1 = this.x - (pair as FazzyNumber)!.x - this.e1 - (pair as FazzyNumber)!.e1;
        double ee2 = this.x - (pair as FazzyNumber)!.x;
        double ee3 = this.x - (pair as FazzyNumber)!.x + this.e2 + (pair as FazzyNumber)!.e2;
        return new FazzyNumber(ee1, ee2, ee3) as Pair;
    }

    public Pair Multiply(Pair pair)
    {
        double ee1 = this.x * (pair as FazzyNumber)!.x - (pair as FazzyNumber)!.x * this.e1 - this.x * (pair as FazzyNumber)!.e1 + this.e1 * (pair as FazzyNumber)!.e1;
        double ee2 = this.x * (pair as FazzyNumber)!.x;
        double ee3 = this.x * (pair as FazzyNumber)!.x + (pair as FazzyNumber)!.x * this.e1 + this.x * (pair as FazzyNumber)!.e1 + this.e1 * (pair as FazzyNumber)!.e1;
        return new FazzyNumber(ee1, ee2, ee3) as Pair;
    }
    public FazzyNumber Return()
    {
        if (this.x > 0)
        {
            double ee1 = 1 / (this.x + this.e2);
            double ee2 = 1 / this.x;
            double ee3 = 1 / (this.x - this.e1);
            return new FazzyNumber(ee1, ee2, ee3);
        }
        else return new FazzyNumber(0, 0, 0);
    }
    public FazzyNumber Division(FazzyNumber number)
    {
        if (number.x > 0)
        {
            double ee1 = (this.x - this.e1) / (number.x - number.e2);
            double ee2 = this.x / number.x;
            double ee3 = (this.x - this.e2) / (number.x - number.e1);
            return new FazzyNumber(ee1, ee2, ee3);
        }
        else return new FazzyNumber(0, 0, 0);
    }

    public override string? ToString()
    {
        return $"{x}, {e1}, {e2}";
    }
}