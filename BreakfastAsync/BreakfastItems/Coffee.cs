namespace BreakfastAsync.BreakfastItems;

public class Coffee : BreakfastItem{
  public Coffee(string finishedMessage = "coffee is ready") => (FinishedMessage) = finishedMessage;

  public void PourCoffee() {
    Console.WriteLine("Pouring coffee");
  }
}
