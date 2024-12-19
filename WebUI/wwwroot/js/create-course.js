const uploadBoxThumbnail = document.getElementById('uploadBoxThumbnail');
const uploadBoxVideo = document.getElementById('uploadBoxVideo');
const imageUpload = document.getElementById('imageUpload');
const videoUpload = document.getElementById('videoUpload');
const attachmentUpload = document.getElementById('attachmentUpload');
const text = document.getElementById('text');
const imagePreview = document.getElementById('preview');
const loadingText = document.querySelector("#loadingText");

imageUpload.addEventListener('change', function () {
    const file = this.files[0];
    if (file && file.size < 5242880) {
        const reader = new FileReader();
        reader.onload = function () {
            imagePreview.src = reader.result;
            imagePreview.style.opacity = 1;
            text.style.display = "none";
        }
        reader.readAsDataURL(file);
    }
    else {

    }
});

videoUpload.addEventListener('change', function () {
    const file = this.files[0];

    if (file && file.size < 1_073_741_824) {
        var reader = new FileReader();
        const videoText = document.getElementById('videoText');
        const loadingText = document.getElementById('loadingText'); // Ensure this element exists in your HTML

        reader.onload = function (e) {
            videoText.innerHTML = `
      <video id="video-tag" class="" style="box-shadow: 0px 0px 10px lightgrey; border-radius: 10px; width: 300px; height: 250px; display: none;">
        <source id="video-source">
        Your browser does not support the video tag.
      </video>`;

            const videoSrc = document.querySelector("#video-source");
            const videoTag = document.querySelector("#video-tag");

            loadingText.style.display = "flex"; // Show the loading text
            videoTag.style.display = 'flex';
            videoSrc.src = e.target.result;

            videoTag.load(); // Start loading the video

            // Listen for the `loadeddata` event
            videoTag.addEventListener('loadeddata', function () {
                loadingText.style.display = "none"; // Hide the loading text
            });

            // Optional: Handle errors
            videoTag.addEventListener('error', function () {
                loadingText.style.display = "none";
                alert("Error loading video");
            });
        }.bind(this);

        reader.readAsDataURL(file);
    } else {
        text.innerHTML = "File is too big ⚠️";
    }
});

attachmentUpload.addEventListener('change', function () {
    const input = document.getElementsByClassName('attachmentName')[0];
    const file = attachmentUpload.files[0];

    if (file && file.size < 20_971_520) {

        input.innerHTML = file.name.slice(0, 16) + '...';
    }
    else {
        input.innerHTML = "File is too big ⚠️";
    }

})

//
//  Staging JS
//

let currentStage = 1;
let lastStage = 1

function showStage(stage) {
    // Hide all stages
    const stages = document.querySelectorAll('.stage');
    const states = document.querySelectorAll('.state');
    stages.forEach(s => s.style.display = 'none');

    states.forEach(state => {
        if (state.id == currentStage) {

            if (currentStage < lastStage) {

                states[lastStage - 1].classList.toggle("done");
            } else {
                state.classList.toggle("done");
            }

            lastStage = currentStage
        }
    });

    // Show the selected stage
    const activeStage = document.getElementById(`stage-${stage}`);
    activeStage.style.display = 'flex';

    // Update navigation indicators
    const navItems = document.querySelectorAll('.nav-item');
    navItems.forEach(item => item.classList.remove('active'));

    const activeNavItem = document.querySelector(`.nav-item[data-stage="${stage}"]`);
    if (activeNavItem) activeNavItem.classList.add('active');
}

function nextStage(next) {
    currentStage = next;
    showStage(currentStage);
}

function prevStage(prev) {
    currentStage = prev;
    showStage(currentStage);
}

function submitCourse() {
    swal({
        title: "Are you sure?",
        text: "Make sure that everthing is correct before publishing your course",
        icon: "info",
        buttons: true,
    })
        .then((published) => {
            if (published) {
                swal("Successfully published!", {
                    icon: "success",
                });
            }
        });
}

function sleep(milliseconds) {
    var start = new Date().getTime();
    for (var i = 0; i < 1e7; i++) {
        if ((new Date().getTime() - start) > milliseconds) {
            break;
        }
    }
}