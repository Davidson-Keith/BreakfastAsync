namespace BreakfastAsync {
  /**
   * Playing with Microsoft's Learning page "Asynchronous programming with async and await":
   * https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
   */
  class Program {
    static async Task Main(String[] args) {
      Coffee cup = PourCoffee();
      var eggsTask = FryEggsAsync(2);
      var baconTask = FryBaconAsync(3);
      var toastTask = MakeToastWithButterAndJamAsync(2);

      var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
      while (breakfastTasks.Count > 0) {
        Task finishedTask = await Task.WhenAny(breakfastTasks);
        await finishedTask;
        breakfastTasks.Remove(finishedTask);
      }

      Juice oj = PourOJ();
      Console.WriteLine("Breakfast is ready!");
    }

    static async Task<Toast> MakeToastWithButterAndJamAsync(int number) {
      var toast = await ToastBreadAsync(number);
      ApplyButter(toast);
      ApplyJam(toast);
      return toast;
    }

    private static Juice PourOJ() {
      Juice oj = new Juice();
      oj.PourOJ();
      return oj;
    }

    private static void ApplyJam(Toast toast) =>
      Console.WriteLine("Putting jam on the toast");

    private static void ApplyButter(Toast toast) =>
      Console.WriteLine("Putting butter on the toast");

    private static async Task<Toast> ToastBreadAsync(int slices) {
      for (int slice = 0; slice < slices; slice++) {
        Console.WriteLine("Putting a slice of bread in the toaster");
      }

      Console.WriteLine("Start toasting...");
      await Task.Delay(3000);
      Console.WriteLine("Remove toast from toaster");

      return new Toast();
    }

    private static async Task<Bacon> FryBaconAsync(int slices) {
      Bacon bacon = new Bacon(slices);
      bacon.AddBaconToPan();
      bacon.CookFirstSideOfBacon();
      await Task.Delay(3000);
      for (int slice = 0; slice < slices; slice++) {
        bacon.FlipBacon();
        await Task.Delay(1000);
      }

      bacon.CookSecondSideOfBacon();
      await Task.Delay(3000);
      bacon.PutBaconOnPlate();
      return bacon;
    }

    private static async Task<Egg> FryEggsAsync(int howMany) {
      Console.WriteLine("Warming the egg pan...");
      await Task.Delay(3000);
      Console.WriteLine($"cracking {howMany} eggs");
      Console.WriteLine("cooking the eggs ...");
      await Task.Delay(3000);
      Console.WriteLine("Put eggs on plate");

      return new Egg();
    }

    internal static Coffee PourCoffee() {
      Console.WriteLine("Pouring coffee");
      return new Coffee();
    }
  }

  internal class BreakfastItem {
    protected string FinishedMessage { get; set; } = "something happened... but what?";
  }

  internal class Bacon : BreakfastItem {
    private readonly int rashers = 0;

    public Bacon(int rashers, string finishedMessage = "bacon is ready") {
      FinishedMessage = finishedMessage;
      this.rashers = rashers;
    }

    public void AddBaconToPan() => Console.WriteLine($"putting {rashers} rashers of bacon in the pan");
    public void CookFirstSideOfBacon() => Console.WriteLine($"cooking first side of bacon...");
    public void FlipBacon() => Console.WriteLine($"flipping a rasher of bacon");
    public void CookSecondSideOfBacon() => Console.WriteLine($"cooking the second side of bacon...");
    public void PutBaconOnPlate() => Console.WriteLine($"Put bacon on plate");
  }

  internal class Coffee : BreakfastItem {
    public Coffee(string finishedMessage = "coffee is ready") => (FinishedMessage) = finishedMessage;
  }

  internal class Egg : BreakfastItem {
    public Egg(string finishedMessage = "eggs are ready") => (FinishedMessage) = finishedMessage;
  }

  internal class Juice : BreakfastItem {
    public Juice(string finishedMessage = "juice is ready") => (FinishedMessage) = finishedMessage;

    public void PourOJ() {
      Console.WriteLine(FinishedMessage);
    }
  }

  internal class Toast : BreakfastItem {
    public Toast(string finishedMessage = "toast is ready") {
      FinishedMessage = finishedMessage;
    }
  }
}