`CoffeeDecorator` - pseudocode:
```
interface Coffee:
    method Description() -> string
    method Cost() -> float

class SimpleCoffee implements Coffee:
    method Description() -> string:
        return "Simple coffee"

    method Cost() -> float:
        return 1.00

abstract class CoffeeDecorator implements Coffee:
    protected Coffee _coffee

    constructor CoffeeDecorator(coffee: Coffee):
        this._coffee = coffee

    method Description() -> string:
        return _coffee.Description()

    method Cost() -> float:
        return _coffee.Cost()

class MilkDecorator extends CoffeeDecorator:
    constructor MilkDecorator(coffee: Coffee):
        base(coffee)

    method Description() -> string:
        return $"{_coffee.Description()}, Milk"

    method Cost() -> float:
        return _coffee.Cost() + 0.50 // dodatkowa opłata za mleko

class SugarDecorator extends CoffeeDecorator:
    constructor SugarDecorator(coffee: Coffee):
        base(coffee)

    method Description() -> string:
        return $"{_coffee.Description()}, Sugar"

    method Cost() -> float:
        return _coffee.Cost() + 0.25 // dodatkowa opłata za cukier

class Client:
    method OrderCoffee(coffee: Coffee):
        print("Your order:", coffee.Description())
        print("Total cost: $" + coffee.Cost())

client = new Client()

simpleCoffee = new SimpleCoffee()
client.OrderCoffee(simpleCoffee)
milkCoffee = new MilkDecorator(simpleCoffee)

client.OrderCoffee(milkCoffee)
sugarMilkCoffee = new SugarDecorator(milkCoffee)
client.OrderCoffee(sugarMilkCoffee)
```
