import pandas as pd

input = open('CaloriesInput.txt', 'r').read()

splitStrings = input.split('\n')

elfsCalories = []
caloriesPerElf = 0

for str in splitStrings:
    if str == '':
        elfsCalories.append(caloriesPerElf)
        caloriesPerElf = 0
        continue

    caloriesOfOneMeal = int(str)
    caloriesPerElf += caloriesOfOneMeal

elfsCalories.sort(reverse=True)
print(f"The maximum amount of calories is: {elfsCalories[0]}")

caloriesOfTopThreeElfs = sum(elfsCalories[0:3])
print(f"The calories of the top three elfs is: {caloriesOfTopThreeElfs}")