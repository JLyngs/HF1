document.addEventListener('DOMContentLoaded', function() {
    const words = ["forgot about it", "don't like coffee", "like it that way?"];
    let i = 0;
    let timer;

    function typingEffect() {
        let word = words[i].split("");
        let loopTyping = function() {
            if (word.length > 0) {
                document.querySelector('.typing').innerHTML += word.shift();
                let delay = word[0] === ' ' ? 30 : 60;
                timer = setTimeout(loopTyping, delay);
            } else {
                setTimeout(deletingEffect, 2000);
            }
        };
        loopTyping();
    }

    function deletingEffect() {
        let word = words[i].split("");
        let loopDeleting = function() {
            if (word.length > 0) {
                word.pop();
                document.querySelector('.typing').innerHTML = word.join("");
                timer = setTimeout(loopDeleting, 30);
            } else {
                if (words.length > (i + 1)) {
                    i++;
                } else {
                    i = 0;
                }
                timer = setTimeout(typingEffect, 100);

            }
        };
        loopDeleting();
    }

    typingEffect();
});