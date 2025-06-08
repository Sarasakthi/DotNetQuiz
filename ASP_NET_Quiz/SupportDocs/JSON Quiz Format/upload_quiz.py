import firestore
import firebase_admin
from firebase_admin import credentials, firestore
import json

# Step 1: Load Firebase credentials
cred = credentials.Certificate("asp-net-quiz-firebase-key.json")
firebase_admin.initialize_app(cred)

# Step 2: Connect to Firestore
db = firestore.client()

# Step 3: Load JSON data
with open("QuestionData.json", "r", encoding="utf-8") as f:
    questions = json.load(f)

# Step 4: Upload each question
for index, q in enumerate(questions):
    doc_ref = db.collection("QuestionSet").document(f"Q{index+1}")
    doc_ref.set(q)

print("✅ Successfully uploaded all questions!")
