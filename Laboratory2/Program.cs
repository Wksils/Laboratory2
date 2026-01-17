using System.Reflection.Metadata.Ecma335;

abstract class Pair
{
    public abstract Pair Plus(Pair pair);
    public abstract Pair Minus(Pair pair);
    public abstract Pair Multiply(Pair pair);
}
class FazzyNumber : Pair
{
    public double x {  get; set; }
    public double e1 { get; set; }
    public double e2 { get; set; }

    public FazzyNumber(double x, double e1, double e2)
    {
        this.x = x;
        this.e1 = e1;
        this.e2 = e2;
    }

    public override Pair Plus(Pair pair)
    {
        double e1=this.x+(pair as FazzyNumber)!.x-this.e1-(pair as FazzyNumber)!.e1;
        double e2 = this.x + (pair as FazzyNumber)!.x;
        double e3 = this.x + (pair as FazzyNumber)!.x + this.e2 + (pair as FazzyNumber)!.e2;
        return new FazzyNumber(e1,e2,e3) as Pair;
    }

    public override Pair Minus(Pair pair)
    {
        double e1 = this.x - (pair as FazzyNumber)!.x - this.e1 - (pair as FazzyNumber)!.e1;
        double e2 = this.x - (pair as FazzyNumber)!.x;
        double e3 = this.x - (pair as FazzyNumber)!.x + this.e2 + (pair as FazzyNumber)!.e2;
        return new FazzyNumber(e1, e2, e3) as Pair;
    }

    public override Pair Multiply(Pair pair)
    {
        double e1 = this.x * (pair as FazzyNumber)!.x - (pair as FazzyNumber)!.x * this.e1 - this.x * (pair as FazzyNumber)!.e1 + this.e1 * (pair as FazzyNumber)!.e1;
        double e2 = this.x * (pair as FazzyNumber)!.x;
        double e3 = this.x * (pair as FazzyNumber)!.x + (pair as FazzyNumber)!.x * this.e1 + this.x * (pair as FazzyNumber)!.e1 + this.e1 * (pair as FazzyNumber)!.e1;
        return new FazzyNumber(e1, e2, e3) as Pair;
    }
    public FazzyNumber Return()
    {
        if (this.x > 0)
        {
            double e1 = 1 / (this.x + this.e2);
            double e2 = 1 / this.x;
            double e3 = 1 / (this.x - this.e1);
            return new FazzyNumber(e1, e2, e3);
        }
        else return new FazzyNumber(0,0, 0);
    }
    public FazzyNumber Division(FazzyNumber number)
    {
        if (number.x > 0)
        {
            double e1 = (this.x - this.e1)/(number.x - number.e2);
            double e2 = this.x / number.x;
            double e3 = (this.x - this.e2)/(number.x - number.e1);
            return new FazzyNumber(e1,e2,e3);
        }
        else return new FazzyNumber(0, 0, 0);
    }
}
class Fraction : Pair
{
    public int d;
    public Fraction()
    {
    }

    public override Pair Minus()
    {
        throw new NotImplementedException();
    }

    public override Pair Multiply()
    {
        throw new NotImplementedException();
    }

    public override Pair Plus()
    {
        throw new NotImplementedException();
    }
}