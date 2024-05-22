namespace BreakfastAsync.BreakfastItems;

public class Bacon : BreakfastItem{

  public Bacon(int rashers, string finishedMessage = "bacon is ready") {
    FinishedMessage = finishedMessage;
    NumberOfItems = rashers;
  }

  public async Task<Bacon> FryBaconAsync() {
    AddBaconToPan();
    CookFirstSideOfBacon();
    await Task.Delay(3000);
    for (int slice = 0; slice < NumberOfItems; slice++) {
      FlipBacon();
      await Task.Delay(1000);
    }

    CookSecondSideOfBacon();
    await Task.Delay(3000);
    PutBaconOnPlate();
    return this;
  }
  public void AddBaconToPan() => Console.WriteLine($"putting {NumberOfItems} rashers of bacon in the pan");
  public void CookFirstSideOfBacon() => Console.WriteLine($"cooking first side of bacon...");
  public void FlipBacon() => Console.WriteLine($"flipping a rasher of bacon");
  public void CookSecondSideOfBacon() => Console.WriteLine($"cooking the second side of bacon...");
  public void PutBaconOnPlate() => Console.WriteLine($"Put bacon on plate");
}
