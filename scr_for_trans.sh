#!/bin/bash

if [ -z "$1" ]; then
  echo "❌ $0 <git-url>"
  exit 1
fi

REPO_URL="$1"
REPO_NAME=$(basename -s .git "$REPO_URL")

echo "🔄 Clone: $REPO_URL ..."
git clone "$REPO_URL"

if [ $? -ne 0 ]; then
  echo "❌ Er clone."
  exit 1
fi

cd "$REPO_NAME" || { echo "❌ Not $REPO_NAME"; exit 1; }

echo "🧹 Remove .git ..."
rm -rf .git

cd ..

echo "✅"

