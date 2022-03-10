class Display
{
    String formatString;
    private  void pricePrintingFormat()
    {
        string fmt = ".00";
        formatString = "{0:" + fmt + "}";
        

    }
    public void display(String msg , double val)
    {  pricePrintingFormat();
        Console.Write(msg);
        Console.WriteLine(formatString, val);
        
      
       
    }


}