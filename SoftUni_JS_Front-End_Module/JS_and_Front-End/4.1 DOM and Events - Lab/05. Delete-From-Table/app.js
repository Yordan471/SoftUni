function deleteByEmail() {
  const emailToDelete = document.querySelector('input[name="email"]');
  const emailBoxes = Array.from(
    document.querySelectorAll("td:nth-child(even)")
  );

  const userEmailBox = emailBoxes.find(
    (email) => email.textContent === emailToDelete.value
  );
  const result = document.getElementById("result");

  if (userEmailBox) {
    userEmailBox.parentElement.remove();
    result.textContent = "Deleted.";
  } else {
    result.textContent = "Not found.:";
  }
}
