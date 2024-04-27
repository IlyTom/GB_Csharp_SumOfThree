namespace SumOfThree
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] nums = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            int target = 15;
            var result = ThreeSum(nums, target);
            if (result != null)
            {
                foreach (List<int> list in result)
                {
                    Console.WriteLine($"Числа которые дают в сумме {target}: {list[0]}, {list[1]}, {list[2]}");
                }                
            }
            else
            {
                Console.WriteLine($"Чисел которые дают в сумме {target} нет");
            }
        }

        public static List<List<int>> ThreeSum(int[] nums, int target)
        {
            var results = new List<List<int>>();
            if (nums == null || nums.Length < 3)
                return results;

            Array.Sort(nums);

            for (int i = 0; i < nums.Length - 2; i++)
            {
                if (i > 0 && nums[i] == nums[i - 1]) continue;
                int left = i + 1, right = nums.Length - 1;
                while (left < right)
                {
                    int sum = nums[i] + nums[left] + nums[right];
                    if (sum == target)
                    {
                        results.Add(new List<int> { nums[i], nums[left], nums[right] });
                        while (left < right && nums[left] == nums[left + 1]) left++;
                        while (left < right && nums[right] == nums[right - 1]) right--;
                        left++; right--;
                    }
                    else if (sum < target)
                    {
                        left++;
                    }
                    else
                    {
                        right--;
                    }
                }
            }

            return results;
        }
    }
}