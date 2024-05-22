namespace BreakfastAsync.BreakfastItems;

public class Juice : BreakfastItem{
  public Juice(string finishedMessage = "juice is ready") => (FinishedMessage) = finishedMessage;

  public void PourOJ() {
    Console.WriteLine(FinishedMessage);
  }
}
