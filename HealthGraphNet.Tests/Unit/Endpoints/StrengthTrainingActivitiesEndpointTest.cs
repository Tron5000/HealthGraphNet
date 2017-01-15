using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using Moq;
using HealthGraphNet;
using HealthGraphNet.Models;

namespace HealthGraphNet.Tests.Unit
{
    [TestFixture()]
    public class StrengthTrainingActivitiesEndpointTest
    {
        #region Fields, Properties and Setup

        protected StrengthTrainingActivitiesPastModel ValidActivity { get; set; }

        protected StrengthTrainingActivitiesNewModel ValidActivityNew { get; set; }

        [SetUp()]
        public void Init()
        {
            ValidActivity = new StrengthTrainingActivitiesPastModel
            {
                StartTime = DateTime.Now,
                TotalCalories = 100,
                Notes = "Good workout!",
                Exercises = new List<ExercisesModel>
                {
                    new ExercisesModel
                    {
                        PrimaryType = "Dumbbell Tricep Press",
                        SecondaryType = "Exercising the tricep.",
                        PrimaryMuscleGroup = "Arms",
                        SecondaryMuscleGroup = "Shoulders",
                        Routine = "Exercising the tricep.",
                        Notes = "Exercising the tricep.",
                        Sets = new List<SetsModel>
                        {
                            new SetsModel
                            {
                                Weight = 20,
                                Repetitions = 10,
                                Notes = "Not too heavy."
                            },
                            new SetsModel
                            {
                                Weight = 50,
                                Repetitions = 20,
                                Notes = "Whoa, too heavy."
                            }
                        }
                    }
                }
            };

            ValidActivityNew = new StrengthTrainingActivitiesNewModel
            {
                StartTime = DateTime.Now,
                TotalCalories = 100,
                Notes = "Good workout!",
                Exercises = new List<ExercisesModel>
                {
                    new ExercisesModel
                    {
                        PrimaryType = "Dumbbell Tricep Press",
                        SecondaryType = "Exercising the tricep.",
                        PrimaryMuscleGroup = "Arms",
                        SecondaryMuscleGroup = "Shoulders",
                        Routine = "Exercising the tricep.",
                        Notes = "Exercising the tricep.",
                        Sets = new List<SetsModel>
                        {
                            new SetsModel
                            {
                                Weight = 20,
                                Repetitions = 10,
                                Notes = "Not too heavy."
                            },
                            new SetsModel
                            {
                                Weight = 50,
                                Repetitions = 20,
                                Notes = "Whoa, too heavy."
                            }
                        }
                    }
                },
                PostToFacebook = false,
                PostToTwitter = false
            };
        }

        #endregion

        #region Tests

        [Test]
        public void GetActivity_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel { StrengthTrainingActivities = validPath });
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.GetActivity(validPath); });
        }

        [Test]
        public void GetActivity_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel { StrengthTrainingActivities = validPath });
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.GetActivity("Not validPath."); });
        }

        [Test]
        public void DeleteActivity_UriValid_DoesNotThrowArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel { StrengthTrainingActivities = validPath });
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.DeleteActivity(validPath); });
        }

        [Test]
        public void DeleteActivity_UriNotValid_ArgumentException()
        {
            //Arrange
            var validPath = "/test/";
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel { StrengthTrainingActivities = validPath });
            //Act and Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.DeleteActivity("Not validPath."); });
        }

        [Test]
        public void UpdateActivity_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_NotesNull_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Notes = null;
            //Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_NotesTenThousandTwentyFiveCharacters_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            string charactersCount1025 = string.Empty;
            for (var count = 0; count <= 1024; count++)
            {
                charactersCount1025 += "A";
            }
            ValidActivity.Notes = charactersCount1025;
            //Assert
            Assert.AreEqual(1025, ValidActivity.Notes.Length);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExercisesNull_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExercisesEmptyList_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises = new List<ExercisesModel>();
            //Assert
            Assert.AreEqual(0, ValidActivity.Exercises.Count);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExercisePrimaryTypeNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises.First().PrimaryType = "Not a valid exercise type.";
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExercisePrimaryMuscleGroupNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises.First().PrimaryMuscleGroup = "Not a valid muscle group.";
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExerciseSecondaryMuscleGroupNull_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises.First().SecondaryMuscleGroup = null;
            //Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExerciseSecondaryMuscleGroupNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises.First().SecondaryMuscleGroup = "Not a valid muscle group.";
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExerciseRoutineNull_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises.First().Routine = null;
            //Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExerciseRoutineThirtyThreeCharacters_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            string charactersCount33 = string.Empty;
            for (var count = 0; count <= 32; count++)
            {
                charactersCount33 += "A";
            }
            ValidActivity.Exercises.First().Routine = charactersCount33;
            //Assert
            Assert.AreEqual(33, ValidActivity.Exercises.First().Routine.Length);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExerciseNotesNull_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises.First().Notes = null;
            //Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExerciseNotesTenThousandTwentyFiveCharacters_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            string charactersCount1025 = string.Empty;
            for (var count = 0; count <= 1024; count++)
            {
                charactersCount1025 += "A";
            }
            ValidActivity.Exercises.First().Notes = charactersCount1025;
            //Assert
            Assert.AreEqual(1025, ValidActivity.Exercises.First().Notes.Length);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExerciseSetNull_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises.First().Sets = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExerciseSetEmptyList_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises.First().Sets = new List<SetsModel>();
            //Assert
            Assert.AreEqual(0, ValidActivity.Exercises.First().Sets.Count);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExerciseSetNotesNull_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivity.Exercises.First().Sets.First().Notes = null;
            //Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void UpdateActivity_ExerciseSetNotesTenThousandTwentyFiveCharacters_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            string charactersCount1025 = string.Empty;
            for (var count = 0; count <= 1024; count++)
            {
                charactersCount1025 += "A";
            }
            ValidActivity.Exercises.First().Sets.First().Notes = charactersCount1025;
            //Assert
            Assert.AreEqual(1025, ValidActivity.Exercises.First().Sets.First().Notes.Length);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.UpdateActivity(ValidActivity); });
        }

        [Test]
        public void CreateActivity_AllPropertiesValid_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act and Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_NotesNull_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Notes = null;
            //Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_NotesTenThousandTwentyFiveCharacters_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            string charactersCount1025 = string.Empty;
            for (var count = 0; count <= 1024; count++)
            {
                charactersCount1025 += "A";
            }
            ValidActivityNew.Notes = charactersCount1025;
            //Assert
            Assert.AreEqual(1025, ValidActivityNew.Notes.Length);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExercisesNull_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExercisesEmptyList_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises = new List<ExercisesModel>();
            //Assert
            Assert.AreEqual(0, ValidActivityNew.Exercises.Count);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExercisePrimaryTypeNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises.First().PrimaryType = "Not a valid exercise type.";
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExercisePrimaryMuscleGroupNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises.First().PrimaryMuscleGroup = "Not a valid muscle group.";
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExerciseSecondaryMuscleGroupNull_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises.First().SecondaryMuscleGroup = null;
            //Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExerciseSecondaryMuscleGroupNotValid_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises.First().SecondaryMuscleGroup = "Not a valid muscle group.";
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExerciseRoutineNull_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises.First().Routine = null;
            //Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExerciseRoutineThirtyThreeCharacters_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            string charactersCount33 = string.Empty;
            for (var count = 0; count <= 32; count++)
            {
                charactersCount33 += "A";
            }
            ValidActivityNew.Exercises.First().Routine = charactersCount33;
            //Assert
            Assert.AreEqual(33, ValidActivityNew.Exercises.First().Routine.Length);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExerciseNotesNull_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises.First().Notes = null;
            //Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExerciseNotesTenThousandTwentyFiveCharacters_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            string charactersCount1025 = string.Empty;
            for (var count = 0; count <= 1024; count++)
            {
                charactersCount1025 += "A";
            }
            ValidActivityNew.Exercises.First().Notes = charactersCount1025;
            //Assert
            Assert.AreEqual(1025, ValidActivityNew.Exercises.First().Notes.Length);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExerciseSetNull_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises.First().Sets = null;
            //Assert
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExerciseSetEmptyList_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises.First().Sets = new List<SetsModel>();
            //Assert
            Assert.AreEqual(0, ValidActivityNew.Exercises.First().Sets.Count);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExerciseSetNotesNull_DoesNotThrowArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            ValidActivityNew.Exercises.First().Sets.First().Notes = null;
            //Assert
            Assert.DoesNotThrowAsync(async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        [Test]
        public void CreateActivity_ExerciseSetNotesTenThousandTwentyFiveCharacters_ArgumentException()
        {
            //Arrange
            Mock<ClientStub> tokenManager = new Mock<ClientStub>();
            StrengthTrainingActivitiesEndpoint activitiesRequest = new StrengthTrainingActivitiesEndpoint(tokenManager.Object, new UsersModel());
            //Act
            string charactersCount1025 = string.Empty;
            for (var count = 0; count <= 1024; count++)
            {
                charactersCount1025 += "A";
            }
            ValidActivityNew.Exercises.First().Sets.First().Notes = charactersCount1025;
            //Assert
            Assert.AreEqual(1025, ValidActivityNew.Exercises.First().Sets.First().Notes.Length);
            Assert.ThrowsAsync(typeof(ArgumentException), async () => { await activitiesRequest.CreateActivity(ValidActivityNew); });
        }

        #endregion
    }
}