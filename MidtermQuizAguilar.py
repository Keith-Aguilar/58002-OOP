class TempConversion:
    def __init__(self, temp):
        self.__temp = temp

    def __to_celsius(self, temp, source_scale):
        if source_scale == 'f':
            return (temp - 32) * 5 / 9
        elif source_scale == 'k':
            return temp - 273.15
        else:  # source_scale == 'c'
            return temp

    def __to_fahrenheit(self, temp, source_scale):
        if source_scale == 'c':
            return temp * 9 / 5 + 32
        elif source_scale == 'k':
            return (temp - 273.15) * 9 / 5 + 32
        else:  # source_scale == 'f'
            return temp

    def __to_kelvin(self, temp, source_scale):
        if source_scale == 'c':
            return temp + 273.15
        elif source_scale == 'f':
            return (temp - 32) * 5 / 9 + 273.15
        else:  # source_scale == 'k'
            return temp

    def fahrenheit_to_celsius(self):
        return self.__to_celsius(self.__temp, 'f')

    def kelvin_to_celsius(self):
        return self.__to_celsius(self.__temp, 'k')

    def celsius_to_fahrenheit(self):
        return self.__to_fahrenheit(self.__temp, 'c')

    def kelvin_to_fahrenheit(self):
        return self.__to_fahrenheit(self.__temp, 'k')

    def celsius_to_kelvin(self):
        return self.__to_kelvin(self.__temp, 'c')

    def fahrenheit_to_kelvin(self):
        return self.__to_kelvin(self.__temp, 'f')

temp = float(input("Enter a temperature: "))
conversion = TempConversion(temp)

print(conversion.fahrenheit_to_celsius())
print(conversion.kelvin_to_celsius())
print(conversion.celsius_to_fahrenheit())
print(conversion.kelvin_to_fahrenheit())
print(conversion.celsius_to_kelvin())
print(conversion.fahrenheit_to_kelvin())


