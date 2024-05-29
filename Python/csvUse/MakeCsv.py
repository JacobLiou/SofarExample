import csv

# with open('data.csv', 'r') as file:
#    read = file.readlines()

# for i in range(len(read)):
#    print(read[i])


age_counts = {}

names = []
ages = []
genders = []

with open('data.csv', 'r') as file:
    file.readline() # skip header
    while(line := file.readline()):
        (name, age, gender) = line.strip().split(',')
        names.append(name)
        ages.append(age)
        genders.append(gender)

for name in names: 
    print(name)
for age in ages: 
    print(age)
for gender in genders: 
    print(gender)


#统计年纪
for age in ages:
    if age in age_counts:
        # 如果存在，则增加计数
        age_counts[age] += 1
    else:
        # 如果不存在，则初始化计数为1
        age_counts[age] = 1

# 打印结果
for age, count in age_counts.items():
    print(f"年龄 {age} 的数量为 {count}")

# 统计年轻人 <=25为年轻人，其他为老年人
for age in ages:
    if int(age) <= 25:
        print("年轻人")
    else:
        print("老年人")
