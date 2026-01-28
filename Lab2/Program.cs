class FazzyNumber
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
    public static FazzyNumber operator + (FazzyNumber a, FazzyNumber b)
    {
        return new FazzyNumber(a.x + b.x - a.e1 - b.e1, a.x + b.x , a.x + b.x + a.e2 + b.e2);
    }
    public static FazzyNumber operator - (FazzyNumber a, FazzyNumber b)
    {
        return new FazzyNumber(a.x - b.x - a.e1 - b.e1, a.x - b.x, a.x - b.x + a.e2 + b.e2);
    }
    public static FazzyNumber operator * (FazzyNumber a, FazzyNumber b)
    {
        return new FazzyNumber(a.x * b.x - b.x * a.e1 - a.x * b.e1 + a.e1 * b.e1, a.x * b.x, a.x * b.x + b.x * a.e1 + a.x * b.e1 + a.e1 * b.e1);
    }
    public static FazzyNumber operator / (FazzyNumber a, FazzyNumber b)
    {
        return new FazzyNumber((a.x - a.e1) / (b.x + b.e2), a.x / b.x, (a.x + a.e2) / (b.x - b.e1));
    }
}