function thePianist(input) {
  input.pop();
  const numOfPieces = Number(input.shift());
  const piecesInfo = input.slice(0, numOfPieces);
  const commands = input.slice(numOfPieces);

  const gatherPieces = piecesInfo.reduce((pieces, line) => {
    const [piece, composer, key] = line.split("|");
    if (!pieces.hasOwnProperty(piece)) {
      pieces[piece] = {
        composer,
        key,
      };
    }

    return pieces;
  }, {});

  commands.forEach((line) => {
    const commandTokens = line.split("|");

    if (commandTokens[0] === "Add") {
      addPiece(commandTokens[1], commandTokens[2], commandTokens[3]);
    } else if (commandTokens[0] === "Remove") {
      removePiece(commandTokens[1]);
    } else {
      changeKey(commandTokens[1], commandTokens[2]);
    }
  });

  const entries = Object.entries(gatherPieces);

  for (const [piece, info] of entries) {
    console.log(`${piece} -> Composer: ${info.composer}, Key: ${info.key}`);
  }

  //Functions

  function addPiece(piece, composer, key) {
    if (!checkIfPieceExists(piece)) {
      gatherPieces[piece] = [];

      gatherPieces[piece] = {
        composer,
        key,
      };

      console.log(`${piece} by ${composer} in ${key} added to the collection!`);
    } else {
      console.log(`${piece} is already in the collection!`);
    }
  }

  function removePiece(piece) {
    if (!checkIfPieceExists(piece)) {
      console.log(
        `Invalid operation! ${piece} does not exist in the collection.`
      );
    } else {
      delete gatherPieces[piece];
      console.log(`Successfully removed ${piece}!`);
    }
  }

  function changeKey(piece, newKey) {
    if (!checkIfPieceExists(piece)) {
      console.log(
        `Invalid operation! ${piece} does not exist in the collection.`
      );
    } else {
      const changeKey = gatherPieces[piece];
      changeKey.key = newKey;
      console.log(`Changed the key of ${piece} to ${newKey}!`);
    }
  }

  function checkIfPieceExists(piece) {
    const pieceExists = gatherPieces.hasOwnProperty(piece);

    return pieceExists;
  }
}

thePianist([
  "4",
  "Eine kleine Nachtmusik|Mozart|G Major",
  "La Campanella|Liszt|G# Minor",
  "The Marriage of Figaro|Mozart|G Major",
  "Hungarian Dance No.5|Brahms|G Minor",
  "Add|Spring|Vivaldi|E Major",
  "Remove|The Marriage of Figaro",
  "Remove|Turkish March",
  "ChangeKey|Spring|C Major",
  "Add|Nocturne|Chopin|C# Minor",
  "Stop",
]);
