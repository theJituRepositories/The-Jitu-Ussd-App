using System;

namespace library_service
{
    public class PurchaseCourse
    {
        private CourseService _courseService;
        private int CurrentBalance;

        public PurchaseCourse(CourseService courseService, int currentBalance)
        {
            _courseService = courseService;
            CurrentBalance = currentBalance;
        }

        public void Purchase(CoursePlanDto selectedCourse)
        {
            Console.WriteLine("Proceed to payment? (Y/N)");
            var proceedToPayment = Console.ReadLine();

            if (proceedToPayment?.Trim().ToUpper() == "Y")
            {
                if (CurrentBalance < selectedCourse.CourseFee)
                {
                    Console.WriteLine("Insufficient Balance. Please credit your account.");
                    return;
                }

                // Deduct the course fee from the current balance
                CurrentBalance -= selectedCourse.CourseFee;

                // Perform the purchase (remove the course from the list)
                _courseService.PurchaseCourse(selectedCourse.CourseId);

                Console.WriteLine("Course purchased successfully.");
                Console.WriteLine($"Remaining balance: {CurrentBalance}");
            }
            else
            {
                Console.WriteLine("Purchase canceled.");
            }
        }
    }
}