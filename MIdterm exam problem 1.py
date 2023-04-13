class Circle:
    def __init__(self, radius=None, diameter=None):
        if radius is not None:
            self.radius = radius
        elif diameter is not None:
            self.radius = diameter / 2
        else:
            self.radius = float(input("Enter the radius of the circle: "))

    def area(self):
        return 3.14159 * self.radius ** 2

    def perimeter(self):
        return 2 * 3.14159 * self.radius


circle = Circle()
print("Area of the circle:", circle.area())
print("Perimeter of the circle:", circle.perimeter())
