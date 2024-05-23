namespace BreakfastAsync.BreakfastItems;

public class Eggs : BreakfastItem{
  public Eggs(int numberOfEggs, string finishedMessage = "eggs are ready") {
    NumberOfItems = numberOfEggs;
    (FinishedMessage) = finishedMessage;
  }

  public async Task<Eggs> FryEggsAsync() {
    Console.WriteLine("Warming the egg pan...");
    await Task.Delay(1000);
    Console.WriteLine($"cracking {NumberOfItems} eggs");
    Console.WriteLine("cooking the eggs ...");
    await Task.Delay(1000);
    Console.WriteLine("Put eggs on plate");
    return this;
  }
}