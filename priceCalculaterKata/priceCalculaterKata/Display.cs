class Display
{
    String formatString;
    private  void pricePrintingFormat()
    {
        string fmt = "0.00";
        formatString = "{0:" + fmt + "}";
        

    }
    public void display(String msg , ISO3 currency,double val)
    {   if (val == 0) return;
        pricePrintingFormat();
        Console.Write(msg);
        Console.Write(formatString, val);
        Console.WriteLine(" "+currency);


    }


}