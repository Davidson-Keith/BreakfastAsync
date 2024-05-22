using BreakfastAsync.BreakfastItems;

namespace BreakfastAsync {
  /**
   * Playing with Microsoft's Learning page "Asynchronous programming with async and await":
   * https://learn.microsoft.com/en-us/dotnet/csharp/asynchronous-programming/
   */
  class Program {
    static async Task Main(String[] args) {
      new Coffee().PourCoffee();
      var eggsTask = new Eggs(2).FryEggsAsync();
      var baconTask = new Bacon(3).FryBaconAsync();
      var toastTask = new Toast(2).MakeToastWithButterAndJamAsync();
      var breakfastTasks = new List<Task> { eggsTask, baconTask, toastTask };
      while (breakfastTasks.Count > 0) {
        Task finishedTask = await Task.WhenAny(breakfastTasks);
        await finishedTask;
        breakfastTasks.Remove(finishedTask);
      }

      new Juice().PourOJ();
      Console.WriteLine("Breakfast is ready!");
    }
  }
}

  
  