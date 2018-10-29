// $(function() {
//     var sprite = createSprite(".sprite");

//     setInterval(function () {
//         sprite.nextFrame();
//     }, 500);
// });

const createSprite = sprite => {
    //Minha solução:
    // $(sprite).addClass("frame1");
    // return {
    //     sprite: $(sprite),
    //     frameAtual: 1,
    //     nextFrame: function() {
    //         if (this.frameAtual === 9) return; 
    //         this.sprite.removeClass("frame" + this.frameAtual);
    //         this.frameAtual++;
    //         this.sprite.addClass("frame" + this.frameAtual);
    //     }
    // }
    //Solução do professor:
    const moveFrame = (from, to) => $elemento.removeClass(from)
                                              .addClass(to);

    const hasNext = () => current + 1 <= last;

    const nextFrame = () => {
        if (hasNext()) moveFrame(frames[current], frames[++current]);
    };

    const reset = () => moveFrame(frames[current],frames[current = 0]);

    const isFinished = () => !hasNext();
    
    const $elemento = $(sprite);

    const frames = ['frame1', 'frame2', 'frame3', 'frame4', 'frame5',
                  'frame6', 'frame7', 'frame8', 'frame9'];

    let current = 0;
    const last = frames.length-1;

    $elemento.addClass(frames[current]);

    return {
        nextFrame,
        reset,
        isFinished
    }
};