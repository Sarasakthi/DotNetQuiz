// firebase-upload.js
// Script to upload JSON quiz questions to Firebase Firestore
// Run this script in VS Code terminal: node firebase-upload.js

const admin = require("firebase-admin");
const fs = require("fs");
const path = require("path");

// Initialize Firebase Admin SDK
const serviceAccount = require("./asp-net-quiz-firebase-key.json");

admin.initializeApp({
  credential: admin.credential.cert(serviceAccount),
  projectId: "asp-net-quiz",
});

const db = admin.firestore();

async function uploadQuestionsToFirestore() {
  try {
    console.log("Reading QuestionData.json...");

    // Read the JSON file
    const jsonData = fs.readFileSync("./QuestionData.json", "utf8");
    const questions = JSON.parse(jsonData);

    console.log(`Found ${questions.length} questions to upload`);

    // Create a batch for efficient uploading
    const batch = db.batch();
    let uploadCount = 0;

    questions.forEach((questionData, index) => {
      // Create document reference with auto-generated ID
      const docRef = db.collection("QuestionSet").doc();

      // Transform your data structure to match Firestore format
      const firestoreQuestion = {
        id: docRef.id,
        questionNumber: index + 1,
        question: questionData.Question || questionData.question,
        options: [
          questionData["Option 1"] || questionData.option1,
          questionData["Option 2"] || questionData.option2,
          questionData["Option 3"] || questionData.option3,
          questionData["Option 4"] || questionData.option4,
        ],
        correctResponse:
          questionData["Correct Response"] || questionData.correctResponse,
        explanation: questionData.Explanation || questionData.explanation,
        createdAt: admin.firestore.FieldValue.serverTimestamp(),
      };

      // Add to batch
      batch.set(docRef, firestoreQuestion);
      uploadCount++;

      console.log(
        `Prepared question ${index + 1}: ${firestoreQuestion.question.substring(
          0,
          50
        )}...`
      );
    });

    // Commit the batch
    console.log("Uploading to Firestore...");
    await batch.commit();

    console.log(
      `✅ Successfully uploaded ${uploadCount} questions to Firestore!`
    );
    console.log("Collection: QuestionSet");
    console.log("You can now view your data in the Firebase Console");
  } catch (error) {
    console.error("❌ Error uploading questions:", error);

    if (error.code === "ENOENT") {
      console.log(
        "Make sure QuestionData.json exists in the same directory as this script"
      );
    }

    if (error.message.includes("serviceAccountKey")) {
      console.log(
        "Make sure you have downloaded and placed your Firebase service account key file"
      );
    }
  } finally {
    // Close the admin app
    admin.app().delete();
  }
}

// Run the upload function
uploadQuestionsToFirestore();
